
// Lab1-priprema.h : main header file for the Lab1-priprema application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CLab1pripremaApp:
// See Lab1-priprema.cpp for the implementation of this class
//

class CLab1pripremaApp : public CWinApp
{
public:
	CLab1pripremaApp() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CLab1pripremaApp theApp;
