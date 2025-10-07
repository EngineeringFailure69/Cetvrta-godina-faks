
// I kolokvijum 2022.h : main header file for the I kolokvijum 2022 application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CIkolokvijum2022App:
// See I kolokvijum 2022.cpp for the implementation of this class
//

class CIkolokvijum2022App : public CWinApp
{
public:
	CIkolokvijum2022App() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CIkolokvijum2022App theApp;
