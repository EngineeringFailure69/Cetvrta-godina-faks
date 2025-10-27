
// Septembar 2023.h : main header file for the Septembar 2023 application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CSeptembar2023App:
// See Septembar 2023.cpp for the implementation of this class
//

class CSeptembar2023App : public CWinApp
{
public:
	CSeptembar2023App() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CSeptembar2023App theApp;
