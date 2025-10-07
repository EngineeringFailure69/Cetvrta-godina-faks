
// bager.h : main header file for the bager application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'pch.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CbagerApp:
// See bager.cpp for the implementation of this class
//

class CbagerApp : public CWinApp
{
public:
	CbagerApp() noexcept;


// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CbagerApp theApp;
