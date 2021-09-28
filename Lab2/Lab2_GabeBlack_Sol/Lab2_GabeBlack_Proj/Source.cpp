/*
Programmer: Gabriel Black
Course: CP240 Lab02
Description: service controller
Limitations: Windows only
*/

#include <iostream>
#include <windows.h>
#include "serviceWriterShared.h"

int input;
SERVICE_STATUS_PROCESS status;

int main()
{
	std::cout << "Service Controller App" << std::endl;

	DWORD dwBytesNeeded = 0;

	SC_HANDLE manager = OpenSCManager(
		NULL,                    // local computer
		NULL,                    // servicesActive database 
		SC_MANAGER_ALL_ACCESS);  // full access rights

	if (manager == NULL)
	{
		DWORD error = GetLastError();

		if (error == ERROR_ACCESS_DENIED)
		{
			std::cout << "Access denied. Try running as administrator." << std::endl;
		}
		else
		{
			std::cout << "ERROR: " << error << std::endl;
		}
	}
	else
	{
		std::cout << "Opened SCM OK" << std::endl;

		std::cout << "Attempting to open service..." << std::endl;

		SC_HANDLE openService = OpenService(
			manager,
			SERVICE_NAME,
			SC_MANAGER_ALL_ACCESS | SERVICE_PAUSE_CONTINUE
		);

		if (openService == NULL)
		{
			DWORD error = GetLastError();

			if (error == ERROR_SERVICE_DOES_NOT_EXIST)
			{
				std::cout << "Could not open service. Check if service is installed. " << std::endl;
				return 0;
			}
			else
			{
				std::cout << "Error in opening: " << error << std::endl;
				return 0;
			}
		}
		else
		{
			std::cout << "Opened service OK" << std::endl;

			while (input != 6)
			{
				PrintMenu();
				input = MenuInput();

				if (input == 1)
				{
					std::cout << "Attempting to start service..." << std::endl;

					BOOL serviceStatus = StartServiceA(
						openService,
						0,
						NULL
					);

					QueryServiceStatusEx( //if the service is not started
						openService,
						SC_STATUS_PROCESS_INFO,
						(LPBYTE)&status,
						sizeof(SERVICE_STATUS_PROCESS),
						&dwBytesNeeded
					);

					if(status.dwCurrentState == SERVICE_RUNNING && status.dwCurrentState != SERVICE_PAUSED)
					{
						std::cout << "Service is already running" << std::endl;
					}
					else if (status.dwCurrentState == SERVICE_PAUSED)
					{
						std::cout << "Service is already running but is paused" << std::endl;
					}
					else
					{
						std::cout << "Service started successfully." << std::endl;
					}
				}
				else if (input == 2)
				{
					std::cout << "Attempting to pause service..." << std::endl;

					QueryServiceStatusEx( //if the service is not started
						openService,
						SC_STATUS_PROCESS_INFO,
						(LPBYTE)&status,
						sizeof(SERVICE_STATUS_PROCESS),
						&dwBytesNeeded
					);

					if (status.dwCurrentState == SERVICE_PAUSED || status.dwCurrentState == SERVICE_STOPPED)
					{
						std::cout << "The service either not been started or is paused already" << std::endl;
					}
					else
					{
						ControlService(
							openService,
							SERVICE_CONTROL_PAUSE,
							(LPSERVICE_STATUS)&status
						);

						std::cout << "Service paused successfully." << std::endl;
					}
				}
				else if (input == 3)
				{
					std::cout << "Attempting to continue service..." << std::endl;

					QueryServiceStatusEx( //if the service is not started
						openService,
						SC_STATUS_PROCESS_INFO,
						(LPBYTE)&status,
						sizeof(SERVICE_STATUS_PROCESS),
						&dwBytesNeeded
					);

					if (status.dwCurrentState == SERVICE_RUNNING || status.dwCurrentState == SERVICE_STOPPED)
					{
						std::cout << "Service is either already running or hasnt been started" << std::endl;
					}
					else
					{
						ControlService(
							openService,
							SERVICE_CONTROL_CONTINUE,
							(LPSERVICE_STATUS)&status
						);

						std::cout << "Service continued successfully." << std::endl;
					}
				}
				else if (input == 4)
				{
					std::cout << "Attempting to stop service..." << std::endl;

					QueryServiceStatusEx( //if the service is not started
						openService,
						SC_STATUS_PROCESS_INFO,
						(LPBYTE)&status,
						sizeof(SERVICE_STATUS_PROCESS),
						&dwBytesNeeded
					);

					if (status.dwCurrentState == 0 || status.dwCurrentState == 1)
					{
						std::cout << "The service has not been started" << std::endl;
					}
					else
					{
						ControlService(
							openService,
							SERVICE_CONTROL_STOP,
							(LPSERVICE_STATUS)&status
						);

						std::cout << "Service stopped successfully." << std::endl;
					}
				}
				else if (input == 5)
				{
					if (status.dwCurrentState == 1 || status.dwCurrentState == 0)
					{
						std::cout << "The service is stopped" << std::endl;
					}
					else if (status.dwCurrentState == 4)
					{
						std::cout << "The service is running" << std::endl;
					}
					else if (status.dwCurrentState == 7)
					{
						std::cout << "The service is paused" << std::endl;
					}
					else
					{
						std::cout << "Service status: " << status.dwCurrentState << std::endl;
					}
				}
				else if (input == 6)
				{
					std::cout << "Ending console program" << std::endl;
				}
				else
				{
					std::cout << "That is not a valid input" << std::endl;
				}
			}
		}
		CloseServiceHandle(openService);
	}

	CloseServiceHandle(manager);

	system("pause");

	return 0;
}