/*

Sample code adapted from:

"Windows 98 Programming From The Ground Up", Herbert Schildt, Osborne McGraw-Hill, 1998.  
http://msdn.microsoft.com/en-us/vstudio/hh314556.aspx
http://www.codeproject.com/Articles/227831/A-dialog-based-Win32-C-program

Demonstrates use of dialog box without a main window

Used dialog editor in VS2010 to create dialog box.  

*/

/*
Name: 
Date:
Assignment: Lab01 - WM_TIMER and file reading
Credits:
*/


#include <Windows.h>
#include <wchar.h>
/* usually, the resource editor creates this file to us: */
#include "resource.h"

#include <string> 
#include <iostream>

BOOL CALLBACK DialogFunc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);
const int bufSizeFixed = 80;
CONST DWORD TIMER = 1;
//CONST DWORD TIMER2 = 1;

LPCSTR SZ_FILE = "C:\\zing\\time.txt";

int WINAPI wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE h0, _In_ PWSTR pCmdLine, _In_ int nCmdShow)
{
	HWND hDlg;
	MSG msg;
	BOOL ret;

	//InitCommonControls(); // not used here, but you could use these controls
	hDlg = CreateDialogParam(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), 0, 
		(DLGPROC)DialogFunc, 0);

	ShowWindow(hDlg, nCmdShow);

	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON_STOP), false);

	// message loop 
	while((ret = GetMessage(&msg, 0, 0, 0)) != 0) {
	
		// error
		if(ret == -1) return -1;  
			
		// 0 == not processed, so process message 
		if(IsDialogMessage(hDlg, &msg) == 0) {
			TranslateMessage(&msg); // keyboard input ... 
			DispatchMessage(&msg); // send message to callback function 
		}// end if dialog message
	}// end while

	KillTimer(hDlg, TIMER);
	//KillTimer(hDlg, TIMER2);

	return msg.wParam;
}

BOOL CALLBACK DialogFunc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	WCHAR temp[bufSizeFixed] = L""; // UTF-16
	WCHAR current[bufSizeFixed] = L"";
	INT n;
	DOUBLE d;
	static INT count = 0;

	std::wstring sTemp; // include <string> 

	switch(message)
	{
	case WM_TIMER:
		switch (wParam)
		{
		case TIMER:

			/*count++;
			SetDlgItemInt(hDlg, IDC_EDIT_OUTPUT, count, FALSE);

			break;*/

			SetDlgItemTextA(hDlg, IDC_ERROR_OUTPUT, " ");

			DWORD dwBytesRead;
			CHAR szTime[24];
			HANDLE hFile;

			hFile = CreateFileA(
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
					//std::cout << "Time: " << szTime << std::endl; //NEDD TO: OUTPUT RESULT TO OUTPUT TEXT BOX
					SetDlgItemTextA(hDlg, IDC_FILE_OUTPUT, szTime);

					CloseHandle(hFile);

					DeleteFileA(SZ_FILE);
				}
			}
			else
			{
				DWORD error = GetLastError();

				switch (error)
				{
				case ERROR_FILE_NOT_FOUND:
					SetDlgItemTextA(hDlg, IDC_ERROR_OUTPUT, "File not found...");
					break;

				case ERROR_SHARING_VIOLATION:
					SetDlgItemTextA(hDlg, IDC_ERROR_OUTPUT, "Error created but not closed");
					break;

				default:
					SetDlgItemInt(hDlg, IDC_ERROR_OUTPUT, error, FALSE);
				}
			}

			break;
		}
		break;

	case WM_COMMAND:
		switch(LOWORD(wParam))
		{
		case IDC_BUTTON_TEST: 
			// button handling code here if you want to test something

			break; 
		case IDOK:
			MessageBox(hDlg, L"OK clicked", L"Msg", MB_OK); 
			break; 
		case IDCANCEL:
			// DO NOT change this code
			SendMessage(hDlg, WM_CLOSE, 0, 0);
			return TRUE;

		case IDC_BUTTON_START:

			SetTimer(hDlg, TIMER, 1000, NULL);
			EnableWindow(GetDlgItem(hDlg, IDC_BUTTON_START), false);
			EnableWindow(GetDlgItem(hDlg, IDC_BUTTON_STOP), true);

			break;

		case IDC_BUTTON_STOP:

			KillTimer(hDlg, TIMER);

			EnableWindow(GetDlgItem(hDlg, IDC_BUTTON_START), true);
			EnableWindow(GetDlgItem(hDlg, IDC_BUTTON_STOP), false);

			break;

		/*case IDC_BUTTON_READ:

			DWORD dwBytesRead;
			CHAR szTime[24];
			HANDLE hFile;

			hFile = CreateFileA(
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
					//std::cout << "Time: " << szTime << std::endl; //NEDD TO: OUTPUT RESULT TO OUTPUT TEXT BOX
					SetDlgItemTextA(hDlg, IDC_FILE_OUTPUT, szTime);

				}

				CloseHandle(hFile);

				DeleteFileA(SZ_FILE);
			}
			else
			{
				DWORD error = GetLastError();

				if (error == ERROR_FILE_NOT_FOUND)
				{
					//std::cout << "File not found" << std::endl; //NEDD TO: OUTPUT RESULT TO OUTPUT TEXT BOX
					SetDlgItemTextA(hDlg, IDC_FILE_OUTPUT, "File not found...");
				}
				else
				{
					//std::cout << "Error: " << error << std::endl; //NEDD TO: OUTPUT RESULT TO OUTPUT TEXT BOX
					SetDlgItemTextW(hDlg, IDC_FILE_OUTPUT, (LPCWSTR)error);
				}
			}

			break;
			*/
		case IDC_BUTTON_GET_INPUT:
			// extract the text from the text box

			GetDlgItemText(hDlg, IDC_EDIT_INPUT, temp, 80);

			// convert the string to int (wide to int)
			n = _wtoi(temp);  // returns zero if not a valid number

			// or to a double (wide to float)
			d = _wtof(temp); 
			
			// zero out memory to test conversion back to string
			memset(temp, 0, sizeof(temp)); 

			// convert from int to string
			// int to wide 
			_itow_s(n, temp, 10); 

			// or, easy convert. 
			sTemp = std::to_wstring(d);

			// write text using a char buffer 
			//SetDlgItemText(hDlg, IDC_EDIT_OUTPUT, temp);

			// or

			// write text to a text box using a string 
			//SetDlgItemText(hDlg, IDC_EDIT_OUTPUT, sTemp.c_str());

			// write a number to a text box 
			SetDlgItemInt(hDlg, IDC_EDIT_OUTPUT, n, FALSE); 

			break;
		}
		
		break;

	case WM_CLOSE:
		// DO NOT change this code 
		DestroyWindow(hDlg);
		return TRUE;

	case WM_DESTROY:
		// DO NOT change this code 
		PostQuitMessage(0);
		return TRUE;

	}// end switch

	return FALSE;
}