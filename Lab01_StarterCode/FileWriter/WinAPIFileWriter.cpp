// Programmer: Professor Dellafelice
// Course: CP240 Lab01 
// Description: filewriter code
// Limitations: Windows only

#ifdef UNICODE
#undef UNICODE
#endif

#include <iostream>
#include <conio.h> // console I/O - for keyboard detection
#include <windows.h>

void GetTime(_Out_ PCHAR szTime, _In_ int nBytes);

LPCSTR SZ_FILE = "C:\\zing\\time.txt"; 
LPCSTR SZ_PATH = "C:\\zing";


int main()
{

	std::cout << "program starting..." << std::endl; 

	DWORD dwBytesWritten = 0;
	CHAR szTime[24]; 
	HANDLE hFile; 
	
	// I had to create a subdirectory off of C:/ as didn't have
	// correct permissions to create a file on C:/
	if (CreateDirectory(SZ_PATH, NULL) == FALSE)
	{
		DWORD ECode = GetLastError();
		if (ECode != ERROR_ALREADY_EXISTS)
		{
			std::cout << "Directory Access Failure.  System error code is: " << std::hex << ECode << std::endl;
			Sleep(2000);
			system("pause");
			return -1;
		}
	}

	DeleteFile(SZ_FILE); 

	while(!_kbhit())
	{
		hFile = CreateFile(
					SZ_FILE, 
					GENERIC_WRITE,
					0,						// no sharing 
					NULL,					// no security
					CREATE_NEW,			    // fail if file already exists 
					FILE_ATTRIBUTE_NORMAL,
					NULL					// no template
					); 

		if(hFile == INVALID_HANDLE_VALUE)
		{
			DWORD ECode = GetLastError();

			if (ECode != ERROR_FILE_EXISTS)
			{
				std::cout << "Failed to open file.  System error code is: " << std::hex << ECode << std::endl;
			}
		}
		else
		{
			dwBytesWritten = 0; 
			GetTime(szTime, 24); 
			system("cls"); 
			std::cout << "Writing: " << szTime << std::endl;
			WriteFile(hFile, szTime, strlen(szTime) + 1, &dwBytesWritten, NULL); 
			CloseHandle(hFile); 	
		}

		Sleep(1000);
		
	} 

	system("pause"); 

	return 0; 
}

void GetTime(_Out_ PCHAR szTime, _In_ int nBytes)
{
	SYSTEMTIME now; 

	GetLocalTime(&now); 

	sprintf_s(szTime, nBytes, "%02d:%02d:%02d", now.wHour, now.wMinute, now.wSecond); 
}

