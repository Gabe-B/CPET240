#pragma once

const wchar_t * SERVICE_NAME = L"MsgSender"; 
const char * SZ_FILE = "C:\\zing\\time.txt";
const char * SZ_PATH = "C:\\zing";
const char * SZ_LOG_FILE = "C:\\zing\\log.txt";

void PrintMenu()
{
	std::cout << "What would you like to do?" << std::endl;
	std::cout << "1: start service" << std::endl;
	std::cout << "2: pause service" << std::endl;
	std::cout << "3: resume service" << std::endl;
	std::cout << "4: stop service" << std::endl;
	std::cout << "5: report status of the service" << std::endl;
	std::cout << "6: close program" << std::endl;
}

int MenuInput()
{
	int input;
	std::cout << "What do you want to do: ";
	std::cin >> input;
	return input;
}
