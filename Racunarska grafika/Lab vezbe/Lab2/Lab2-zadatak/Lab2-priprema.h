
// Lab2-priprema.h : main header file for the Lab2-priprema application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CLab2pripremaApp:
// See Lab2-priprema.cpp for the implementation of this class
//

class CLab2pripremaApp : public CWinApp
{
public:
	CLab2pripremaApp() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CLab2pripremaApp theApp;
