
// Vezba.h : main header file for the Vezba application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CVezbaApp:
// See Vezba.cpp for the implementation of this class
//

class CVezbaApp : public CWinApp
{
public:
	CVezbaApp() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CVezbaApp theApp;
