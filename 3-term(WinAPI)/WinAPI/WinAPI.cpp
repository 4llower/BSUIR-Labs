// WinAPI.cpp : Определяет точку входа для приложения.
//

#include "framework.h"
#include "WinAPI.h"

#define MAX_LOADSTRING 100

// Глобальные переменные:
HINSTANCE hInst;                                // текущий экземпляр
WCHAR szTitle[MAX_LOADSTRING];                  // Текст строки заголовка
WCHAR szWindowClass[MAX_LOADSTRING];            // имя класса главного окна

// Отправить объявления функций, включенных в этот модуль кода:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Разместите код здесь.

    // Инициализация глобальных строк
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_WINAPI, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Выполнить инициализацию приложения:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_WINAPI));

    MSG msg;

    // Цикл основного сообщения:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  ФУНКЦИЯ: MyRegisterClass()
//
//  ЦЕЛЬ: Регистрирует класс окна.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_WINAPI));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_WINAPI);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   ФУНКЦИЯ: InitInstance(HINSTANCE, int)
//
//   ЦЕЛЬ: Сохраняет маркер экземпляра и создает главное окно
//
//   КОММЕНТАРИИ:
//
//        В этой функции маркер экземпляра сохраняется в глобальной переменной, а также
//        создается и выводится главное окно программы.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Сохранить маркер экземпляра в глобальной переменной

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  ФУНКЦИЯ: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  ЦЕЛЬ: Обрабатывает сообщения в главном окне.
//
//  WM_COMMAND  - обработать меню приложения
//  WM_PAINT    - Отрисовка главного окна
//  WM_DESTROY  - отправить сообщение о выходе и вернуться
//
//

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{   
    static int lastHandledX = 0, lastHandledY = 0;
    static int currentBrushSize = 10;
    static int currentObjectSize = 5;
    static DrawProperties::Color currentColor = DrawProperties::Color::Blue;
    static DrawProperties::DrawType currentMode = DrawProperties::DrawType::Point;
    static bool isMouseHold = false;

    switch (message)
    {
    case WM_CREATE: {
        CreateBookmarks(hWnd);
        break;
    }
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Разобрать выбор в меню:
            switch (wmId)
            {
            case MENU_ERASER: {
                currentMode = DrawProperties::DrawType::Point;
                currentColor = DrawProperties::Color::White;
                
                break;
            }
            case MENU_CIRCLE: {
                currentMode = DrawProperties::DrawType::Circle;
                break;
            }
            case MENU_SQUARE: {
                currentMode = DrawProperties::DrawType::Square;
                break;
            }
            case MENU_PEN: {
                currentMode = DrawProperties::DrawType::Point;
                currentObjectSize = 5;
                break;
            }
            case MENU_FILLING: {
                currentMode = DrawProperties::DrawType::Filling;
            }
            case MENU_BRUSH_5px: {
                currentBrushSize = 5;
                break;
            }
            case MENU_BRUSH_10px: {
                currentBrushSize = 10;
                break;
            }
            case MENU_BRUSH_25px: {
                currentBrushSize = 25;
                break;
            }
            case MENU_BRUSH_50px: {
                currentBrushSize = 50;
                break;
            case MENU_OBJECT_5px: {
                currentObjectSize = 5;
                break;
            }
            case MENU_OBJECT_10px: {
                currentObjectSize = 10;
                break;
            }
            case MENU_OBJECT_25px: {
                currentObjectSize = 25;
                break;
            }
            case MENU_OBJECT_50px: {
                currentObjectSize = 50;
                break;
            }
            case MENU_COLOR_RED: {
                currentColor = DrawProperties::Color::Red;
                break;
            }
            case MENU_COLOR_BLUE: {
                currentColor = DrawProperties::Color::Blue;
                break;
            }
            case MENU_COLOR_GREEN: {
                currentColor = DrawProperties::Color::Green;
                break;
            }
            }
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
    case WM_KEYDOWN: 
        {
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        }
    case WM_PAINT: {
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            drawHandler->drawCurrentStates(hdc);
            EndPaint(hWnd, &ps);
            break;
        }
    case WM_MOUSEMOVE: {
        if (isMouseHold) {
            if (currentMode == DrawProperties::DrawType::Point) {
                lastHandledX = GET_X_LPARAM(lParam);
                lastHandledY = GET_Y_LPARAM(lParam);
                drawHandler->addNewState({ lastHandledX, lastHandledY, currentMode, currentBrushSize, currentObjectSize, currentColor });
                RedrawWindow(hWnd, NULL, NULL, RDW_INVALIDATE | RDW_INTERNALPAINT);
            }
        }
        break;
    }
    case WM_LBUTTONDOWN: {
        isMouseHold = true;
        break;
    }
    case WM_LBUTTONUP: {
        isMouseHold = false;
        lastHandledX = GET_X_LPARAM(lParam);
        lastHandledY = GET_Y_LPARAM(lParam);
        drawHandler->addNewState({ lastHandledX, lastHandledY, currentMode, currentBrushSize, currentObjectSize, currentColor });
        RedrawWindow(hWnd, NULL, NULL, RDW_INVALIDATE | RDW_INTERNALPAINT);
        break;
    }
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}


void CreateBookmarks(HWND hWnd) {
    HMENU hMenubar = CreateMenu();
    HMENU instrument = CreateMenu();
    HMENU brushSize = CreateMenu();
    HMENU objectSize = CreateMenu();
    HMENU color = CreateMenu();

    AppendMenuW(instrument, MF_STRING, MENU_ERASER, L"&Ластик");
    AppendMenuW(instrument, MF_STRING, MENU_CIRCLE, L"&Круг");
    AppendMenuW(instrument, MF_STRING, MENU_SQUARE, L"&Квадрат");
    AppendMenuW(instrument, MF_STRING, MENU_PEN, L"&Карандаш");
    AppendMenuW(instrument, MF_STRING, MENU_FILLING, L"&Заливка");

    AppendMenuW(brushSize, MF_STRING, MENU_BRUSH_5px, L"&5px");
    AppendMenuW(brushSize, MF_STRING, MENU_BRUSH_10px, L"&10px");
    AppendMenuW(brushSize, MF_STRING, MENU_BRUSH_25px, L"&25px");
    AppendMenuW(brushSize, MF_STRING, MENU_BRUSH_50px, L"&50px");

    AppendMenuW(objectSize, MF_STRING, MENU_OBJECT_5px, L"&5px");
    AppendMenuW(objectSize, MF_STRING, MENU_OBJECT_10px, L"&10px");
    AppendMenuW(objectSize, MF_STRING, MENU_OBJECT_25px, L"&25px");
    AppendMenuW(objectSize, MF_STRING, MENU_OBJECT_50px, L"&50px");

    AppendMenuW(color, MF_STRING, MENU_COLOR_RED, L"&Красный");
    AppendMenuW(color, MF_STRING, MENU_COLOR_GREEN, L"&Зеленый");
    AppendMenuW(color, MF_STRING, MENU_COLOR_BLUE, L"&Синий");

    AppendMenuW(hMenubar, MF_POPUP, (UINT_PTR)instrument, L"&Инструмент");
    AppendMenuW(hMenubar, MF_POPUP, (UINT_PTR)brushSize, L"&Размер кисти");
    AppendMenuW(hMenubar, MF_POPUP, (UINT_PTR)objectSize, L"&Размер обьекта");
    AppendMenuW(hMenubar, MF_POPUP, (UINT_PTR)color, L"&Цвет");

    SetMenu(hWnd, hMenubar);
}
