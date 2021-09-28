/*
FILE:	ServiceWriterWithZingV2.cpp
DESCRIPTION:
Windows service time writer


CREDITS:
Win32 System Services. Brian, Reeves. Prentice-Hall, 2001
http://www.koders.com/cpp/fidC392EE207FC799A509A3063BE2F6555CD4516FDA.aspx?s=windows.h#L7
Ken Thompson (Exacom, Inc.) found the service self install (www.CodeProject.com ??)
Other useful examples
Installing a service (programmatically in C++)
https://msdn.microsoft.com/en-us/library/windows/desktop/ms683500(v=vs.85).aspx
Deleting a service (programmatically in C++)
https://msdn.microsoft.com/en-us/library/windows/desktop/ms682571(v=vs.85).aspx
A simple Windows Service
http://www.codeproject.com/Articles/499465/Simple-Windows-Service-in-Cplusplus

// from the MSDN
https://code.msdn.microsoft.com/windowsapps/CppWindowsService-cacf4948
*/

#include <Windows.h>
//#include <Winsvc.h>
#include <time.h>

// string manipulation 
#include <string> 
#include <sstream>

#include <iostream>

#include "serviceWriterShared.h"

// globals 
SERVICE_STATUS m_ServiceStatus;
SERVICE_STATUS_HANDLE m_ServiceStatusHandle;
BOOL g_bServiceRunning;
HANDLE g_hTerminateEvt;
BOOL gb_pause = FALSE;

// function prototypes
void WINAPI ServiceMain(DWORD argc, LPTSTR *argv);
void WINAPI ServiceCtrlHandler(DWORD Opcode);
BOOL InstallService(PWSTR serviceName);
BOOL DeleteService();
BOOL StartServiceThread();

// constants 
const wchar_t * SERVICE_DISPLAY_NAME = L"Msg Sender"; // provide any display name
const wchar_t* SERVICE_TEXT_DESCRIPTION = L"Writes time to file."; // provide any description
const wchar_t* CMD_INSTALL = L"install";
const wchar_t* CMD_REMOVE = L"remove";
const wchar_t* CMD_DEBUG = L"debug";

int wmain(int argc, wchar_t *argv[])
{
	int nRetCode = 0;


	if ((argc > 1) && // accept reasonable argument prefix 
		((*argv[1] == '-') || (*argv[1] == '/') || (*argv[1] != ' ')))
	{
		std::wstring command = argv[1] + 1; // + 1 to get what is after prefix 
		WCHAR * nameOfExe = argv[0]; 

		if (command == CMD_INSTALL)
		{
			InstallService(nameOfExe);
		}
		else if (command == CMD_REMOVE)
		{
			DeleteService();
		}
		else if (command == CMD_DEBUG)
		{
			// run as console application 

			StartServiceThread();
			while (true)
			{
				Sleep(1000);
			}
		}
		else
		{
			std::wcout << "-" << CMD_INSTALL << ", -" << CMD_REMOVE << ", -" << CMD_DEBUG << std::endl; 
		}

		return nRetCode;

	}
	else { // not enough args.  Must be starting as a service. 

		   // run as service

		   //                                     Note pointer to ServiceMain
		SERVICE_TABLE_ENTRY dispatchTable[] =  //       |
		{                                     //       \|/
			{ (LPWSTR)SERVICE_NAME, (LPSERVICE_MAIN_FUNCTION)ServiceMain },
			{ NULL, NULL } // NULL terminator for array of structs
		};

		// - registr the EXE with the SCM
		// - give the SCM a pointer to a service main function to call
		//   when it wants to start the service. 
		StartServiceCtrlDispatcher(dispatchTable);
	}

	return nRetCode;
}

void GetTime(_Out_ PCHAR szTime, _In_ int nBytes)
{
	SYSTEMTIME now;

	GetLocalTime(&now);

	// encode time into string 
	sprintf_s(szTime, nBytes, "%02d:%02d:%02d", now.wHour, now.wMinute, now.wSecond);
}

DWORD ServiceExecutionThread(LPDWORD pParam)
{
	char msg[64] = { 0 };
	int count = 0;
	DWORD dwBytesWritten = 0;
	CHAR szTime[24];
	HANDLE hFile;

	// I had to create a subdirectory off of C:/ as didn't have
	// correct permissions to create a file on C:/
	if (CreateDirectoryA(SZ_PATH, NULL) == FALSE)
	{
		DWORD ECode = GetLastError();
		if (ECode != ERROR_ALREADY_EXISTS)
		{
			std::cout << "Directory Access Failure.  System error code is: " << std::hex << ECode << std::endl;
			Sleep(2000);
		}
	}

	if (DeleteFileA(SZ_FILE) == FALSE)
	{
		DWORD ECode = GetLastError();
		if (ECode != ERROR_FILE_NOT_FOUND)
		{
			std::cout << "DeleteFile " << SZ_FILE << " error " << std::dec << GetLastError();
		}
	}


	while (g_bServiceRunning) { // this global boolean is set in ServiceCtrlHandler

		if (!gb_pause) {

			hFile = CreateFileA(
				SZ_FILE,
				GENERIC_READ | GENERIC_WRITE,
				0,						// no sharing 
				NULL,					// no security
				CREATE_NEW,             // fail if file exists
				FILE_ATTRIBUTE_NORMAL,
				NULL					// no template
			);

			if (hFile == INVALID_HANDLE_VALUE)
			{
				// create file failed
			}
			else
			{
				dwBytesWritten = 0;
				GetTime(szTime, 24);
				WriteFile(hFile, szTime, (DWORD)strlen(szTime) + 1, &dwBytesWritten, NULL);
				CloseHandle(hFile);
			}

		}// end if not paused

		Sleep(1000); // write time to file every second 

	}// end while g_bServiceRunning

	return 0;

}// end ServiceExecutionThread

BOOL StartServiceThread()
{
	DWORD id;
	HANDLE hServiceThread = CreateThread(0, 0,
		(LPTHREAD_START_ROUTINE)ServiceExecutionThread,
		0, 0, &id);

	if (hServiceThread == 0)
	{
		return false;
	}
	else
	{
		g_bServiceRunning = true;
		return true;
	}
}

// ServiceMain is started when the SCM sends a start message. 
// ServiceMain is executed in a separate thread. 
void WINAPI ServiceMain(DWORD argc, LPTSTR *argv)
{

	// m_ServiceStatus = 0
	memset(&m_ServiceStatus, 0, sizeof(m_ServiceStatus)); 

	// init global data 
	m_ServiceStatus.dwServiceType = SERVICE_WIN32_OWN_PROCESS; 
	m_ServiceStatus.dwControlsAccepted = SERVICE_ACCEPT_STOP | SERVICE_ACCEPT_PAUSE_CONTINUE;

	// Register the service control handler with the SCM.
	// and get a handle we can use to send status messages. 
	m_ServiceStatusHandle = RegisterServiceCtrlHandler(
								SERVICE_NAME,
								ServiceCtrlHandler // callback function 
							);

	if (m_ServiceStatusHandle == (SERVICE_STATUS_HANDLE)0)
	{
		return;
	}

	// if we get to here, the service is running
	m_ServiceStatus.dwCurrentState = SERVICE_RUNNING;

	// Tell the SCM what our status is.  Note that we use the HANDLE 
	// returned from RegisterServiceCtrlHandler.
	if (!SetServiceStatus(m_ServiceStatusHandle, &m_ServiceStatus))
	{
		// no error handling in this example.
		OutputDebugStringA("SetServiceStatus error!!\n");
	}

	// Start the main thread for this service. 
	// A service can have several threads. 
	StartServiceThread();

	g_hTerminateEvt = CreateEvent(0, FALSE, FALSE, 0);

	WaitForSingleObject(g_hTerminateEvt, INFINITE);

	return;
}

// When the SCM has a message for the service, it calls this function.
// This function is registered at the beginning of ServiceMain. 
void WINAPI ServiceCtrlHandler(DWORD Opcode)
{
	switch (Opcode)
	{
	case SERVICE_CONTROL_PAUSE:

		gb_pause = TRUE; 

		m_ServiceStatus.dwCurrentState = SERVICE_PAUSED;
		SetServiceStatus(m_ServiceStatusHandle, &m_ServiceStatus);

		break;
	case SERVICE_CONTROL_CONTINUE:

		gb_pause = FALSE; 

		m_ServiceStatus.dwCurrentState = SERVICE_RUNNING;
		SetServiceStatus(m_ServiceStatusHandle, &m_ServiceStatus);

		break;
	case SERVICE_CONTROL_STOP:
		
		m_ServiceStatus.dwCurrentState = SERVICE_STOPPED;
		SetServiceStatus(m_ServiceStatusHandle, &m_ServiceStatus);

		gb_pause = FALSE;
		g_bServiceRunning = FALSE;

		SetEvent(g_hTerminateEvt);

		break;
	case SERVICE_CONTROL_INTERROGATE:

		break;
	}
	return;
}

BOOL InstallService(PWSTR serviceExe)
{
	// Installing the service from inside the application is clean. 
	// The installion can be done using a separate application. 
	BOOL retVal = TRUE;	// RMD added
	WCHAR strDir[1024]; // where the exe resides

	SC_HANDLE schSCManager; // handle to Service Control Manager
	SC_HANDLE schService;   // handle to your service 

							// where is our application?
	GetCurrentDirectoryW(1024, strDir);

	// combine path and name of application 
	std::wstringstream wstrstr; 
	wstrstr << strDir << "\\" << serviceExe; 
	const std::wstring temp = wstrstr.str();
	const wchar_t * lpszBinaryPathName = temp.c_str();

	std::wcout << "Installing " << lpszBinaryPathName << "..." << std::endl;

	// get a handle to the Service Control Manger (SCM)
	schSCManager = OpenSCManager(NULL, NULL, SC_MANAGER_ALL_ACCESS);

	if (schSCManager == NULL)
	{
		// RMD added
		std::cout << "OpenSCManager Error: "<< std::dec << GetLastError();
		return false;
	}

	schService = CreateService(schSCManager,
		SERVICE_NAME,			// name of service 
		SERVICE_DISPLAY_NAME,	// service name to display
		SERVICE_ALL_ACCESS,		// desired access 
		SERVICE_WIN32_OWN_PROCESS, // service type 
		SERVICE_DEMAND_START,	// start type /// try SERVICE_AUTO_START
		SERVICE_ERROR_NORMAL,	// error control type 
		lpszBinaryPathName,		// service's binary 
		NULL,  // no load ordering group 
		NULL,  // no tag identifier 
		NULL,  // no dependencies
		NULL,  // LocalSystem account
		NULL); // no password

	if (schService == NULL)
	{
		// RMD added
		std::cout << "CreateService Error: " << std::dec << GetLastError();
		return false;
	}

	// add the description of the service
	SERVICE_DESCRIPTION l_sDescription;
	l_sDescription.lpDescription = (LPWSTR)SERVICE_TEXT_DESCRIPTION;
	if (ChangeServiceConfig2(schService, SERVICE_CONFIG_DESCRIPTION, &l_sDescription) == FALSE)
	{
		std::cout << "ChangeServiceConfig2 Error " << std::dec << GetLastError();
		retVal = FALSE;
	}
	else
	{
		std::cout << "Service installed" << std::endl; 
	}

	// done 
	CloseServiceHandle(schService);
	CloseServiceHandle(schSCManager); // RMD added 

	return retVal;
}

BOOL DeleteService()
{
	SC_HANDLE schSCManager; // handle to Service Control Manager
	SC_HANDLE hService;     // handle to your service
	SERVICE_STATUS status;	// for QueryServiceStatus 
	BOOL retVal = true;

	// get a handle to the Service Control Manager
	schSCManager = OpenSCManager(NULL, NULL, SC_MANAGER_ALL_ACCESS);

	if (schSCManager == NULL)
	{
		std::cout << "OpenSCManager failed " << std::dec << GetLastError();
		return false;
	}

	// get a handle to your service 
	hService = OpenService(schSCManager, SERVICE_NAME,
		SERVICE_ALL_ACCESS);

	if (hService == NULL)
	{
		std::cout << "OpenService failed " << std::dec << GetLastError();
		CloseServiceHandle(schSCManager);
		return FALSE;
	}

	// Stop the service if neccessary
	retVal = QueryServiceStatus(hService, &status);
	if (retVal == FALSE)
	{
		std::cout << "QueryServiceStatus failed " << std::dec << GetLastError();
		return FALSE;
	}
	if (status.dwCurrentState != SERVICE_STOPPED)
	{
		std::cout << "Stopping Service...\n"; 
		retVal = ControlService(hService,
			SERVICE_CONTROL_STOP,
			&status);
		if (retVal == FALSE)
		{
			std::cout << "ControlService Error " << std::dec << GetLastError();
			return FALSE;
		}
		Sleep(500);
	}

	// Remove the service
	retVal = DeleteService(hService);
	if (retVal == TRUE)
	{
		std::cout << "Service removed\n";
	}
	else
	{
		std::cout << "DeleteService Error " << std::dec << GetLastError();
		retVal = FALSE;
	}
	// clean up
	CloseServiceHandle(hService);
	CloseServiceHandle(schSCManager);

	return retVal;
}

