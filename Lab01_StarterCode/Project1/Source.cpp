/*#include <iostream>

int f(int a, int b)
{
	return a + b; 
}

void call_function(int (*foo)(int, int))
{
	int sum = foo(3, 4); 

	std::cout << "address of f " << f << std::endl; 
	std::cout << "value of foo " << foo << std::endl; 

	std::cout << "Sum: " << sum << std::endl; // 7
}

int main()
{
	call_function(f); 

	return 0; 
}*/

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

int main()
{

	std::cout << "program starting..." << std::endl;

	DWORD dwBytesRead;
	CHAR szTime[24];
	HANDLE hFile;

	hFile = CreateFile(
		SZ_FILE,
		GENERIC_READ,
		0,						// no sharing 
		NULL,					// no security
		OPEN_EXISTING,			// fail if file already exists 
		FILE_ATTRIBUTE_NORMAL,
		NULL					// no template
	);

	if (hFile != INVALID_HANDLE_VALUE)
	{
		dwBytesRead = sizeof(szTime);

		if (ReadFile(hFile, szTime, sizeof(szTime), &dwBytesRead, NULL))
		{
			std::cout << "Time: " << szTime << std::endl;
		}

		CloseHandle(hFile);

		DeleteFile(SZ_FILE);
	}
	else
	{
		DWORD error = GetLastError();

		if (error == ERROR_FILE_NOT_FOUND)
		{
			std::cout << "File not found" << std::endl;
		}
		else
		{
			std::cout << "Error: " << error << std::endl;
		}
	}

	system("pause");

	return 0;
}