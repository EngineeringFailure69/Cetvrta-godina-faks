
// Septembar 2023View.h : interface of the CSeptembar2023View class
//

#pragma once


class CSeptembar2023View : public CView
{
protected: // create from serialization only
	CSeptembar2023View() noexcept;
	DECLARE_DYNCREATE(CSeptembar2023View)

// Attributes
public:
	CSeptembar2023Doc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void Translate(CDC* pDC, float dx, float dy, bool rightMultiply);
	virtual void Scale(CDC* pDC, float sx, float sy, bool rightMultiply);
	virtual void Rotate(CDC* pDC, float angle, bool rightMultiply);
	virtual void DrawFilmReel(CDC* pDC, int r, int n, int dBig, int rBig, int dSmall, int rSmall, COLORREF colFill, int wLine, COLORREF colLine);
	virtual void DrawFilmReel(CDC* pDC, int r, int n, int dBig, int rBig, int dSmall, int rSmall, COLORREF colFill, int wLine, COLORREF colLine, 
		double angle, int nText, CString strText[], int spacing[], int hFont, COLORREF colText);
	virtual void Save(CDC* pDC, CRect rcDC, CRect rcBmp, CString sFile);

	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CSeptembar2023View();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in Septembar 2023View.cpp
inline CSeptembar2023Doc* CSeptembar2023View::GetDocument() const
   { return reinterpret_cast<CSeptembar2023Doc*>(m_pDocument); }
#endif

