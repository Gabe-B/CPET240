// GabeBlack_FinalConsoleApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
/*
Resources:

https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messageboxindirecta

https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msgboxparamsa

https://voidnish.wordpress.com/2005/01/11/using-messageboxindirect-to-show-message-boxes-with-custom-icons/

https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate

https://stackoverflow.com/questions/6423729/get-current-cursor-position/6423739

http://www.cplusplus.com/forum/beginner/11535/

*/

#include <iostream>
#include <Windows.h>
#include <conio.h>

using namespace std;

int main()
{
	bool looping = true;
	bool hasLooped = false;
	int ch;
	POINT p;
	DWORD_PTR dWord = (DWORD_PTR)"12345";

	MSGBOXPARAMSA MsgBoxParams = { 0 };

	HELPINFO hi = { 0 };
	hi.cbSize = sizeof(hi);
	hi.dwContextId = dWord;

	MsgBoxParams.cbSize = sizeof(MsgBoxParams);
	MsgBoxParams.lpszText = "Keep Going?";
	MsgBoxParams.lpszCaption = "Created with MessageBoxIndirectA";
	MsgBoxParams.dwStyle = MB_YESNOCANCEL | MB_ICONQUESTION | MB_SYSTEMMODAL;

	cout << "Press 'F1' to call the help function or press any key to bring up the menu\n\n";

	while (looping)
	{
		int msgInd;
		const int FKeyFirst = 0;
		const int FKeySecond = 59;

		ch = _getch();

		if (ch == FKeyFirst && !hasLooped)
		{
			GetCursorPos(&p);

			cout << "Help Message. Mouse at: " << p.x << ", " << p.y << endl;

			hasLooped = true;
		}
		else
		{
			if (hasLooped)
			{
				hasLooped = false;
			}
			else
			{
				msgInd = MessageBoxIndirectA(&MsgBoxParams);

				switch (msgInd)
				{
				case IDYES:
					cout << "Keep going. ID# = " << IDYES << "\n";
					break;

				case IDCANCEL:
					cout << "Message box cancelled. ID# = " << IDCANCEL << "\n";
					break;

				case IDNO:
					cout << "Program ended. ID# = " << IDNO << "\n";
					looping = false;
					break;

				default:
					break;
				}
			}
		}
	}

	return 0;
}
