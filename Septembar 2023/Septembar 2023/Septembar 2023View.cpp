
// Septembar 2023View.cpp : implementation of the CSeptembar2023View class
//

#include "pch.h"
#include "framework.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "Septembar 2023.h"
#endif

#include "Septembar 2023Doc.h"
#include "Septembar 2023View.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define PI 3.1415

// CSeptembar2023View

IMPLEMENT_DYNCREATE(CSeptembar2023View, CView)

BEGIN_MESSAGE_MAP(CSeptembar2023View, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CSeptembar2023View construction/destruction

CSeptembar2023View::CSeptembar2023View() noexcept
{
	// TODO: add construction code here

}

CSeptembar2023View::~CSeptembar2023View()
{
}

BOOL CSeptembar2023View::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CSeptembar2023View drawing

void CSeptembar2023View::Translate(CDC* pDC, float dx, float dy, bool rightMultiply)
{
	XFORM transform = { 1,0,0,1,dx,dy };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CSeptembar2023View::Scale(CDC* pDC, float sx, float sy, bool rightMultiply)
{
	XFORM transform = { sx,0,0,sy,0,0 };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CSeptembar2023View::Rotate(CDC* pDC, float angle, bool rightMultiply)
{
	XFORM transform = { cos(angle), sin(angle), -sin(angle), cos(angle) };
	pDC->ModifyWorldTransform(&transform, rightMultiply ? MWT_RIGHTMULTIPLY : MWT_LEFTMULTIPLY);
}

void CSeptembar2023View::DrawFilmReel(CDC* pDC, int r, int n, int dBig, int rBig, int dSmall, int rSmall, COLORREF colFill, int wLine, COLORREF colLine)
{
	CPen* olovkaIvicaSvihKontura = new CPen(PS_SOLID, wLine, colLine);
	CBrush* cetkicaIspuneKontura = new CBrush(colFill);
	CBrush* belaCetkica = new CBrush(RGB(255, 255, 255));
	CPen* staraOlovka = pDC->SelectObject(olovkaIvicaSvihKontura);
	CBrush* staraCetkica = pDC->SelectObject(cetkicaIspuneKontura);
	pDC->Ellipse(-r, -r, +r, +r);
	pDC->SelectObject(belaCetkica);
	//n vecih kruznica
	double novoX = 0;
	double novoY = 0;
	double korak = 2 * PI / n;
	for (double alfa = PI / 2; alfa < 2 * PI + PI / 2; alfa += korak) 
	{
		novoX = dBig * cos(alfa);
		novoY = dBig * sin(alfa);
		pDC->Ellipse(novoX-rBig, novoY-rBig, novoX+rBig, novoY+rBig);
	}
	//4 manje kruznice
	novoX = 0;
	novoY = 0;
	korak = 2 * PI / 4;
	for (double alfa = PI / 2; alfa < 2 * PI + PI / 2; alfa += korak) 
	{
		novoX = dSmall * cos(alfa);
		novoY = dSmall * sin(alfa);
		pDC->Ellipse(novoX - rSmall, novoY - rSmall, novoX + rSmall, novoY + rSmall);
	}
	pDC->SelectObject(staraOlovka);
	pDC->SelectObject(staraCetkica);
	delete cetkicaIspuneKontura;
	delete belaCetkica;
	delete olovkaIvicaSvihKontura;
}

void CSeptembar2023View::DrawFilmReel(CDC* pDC, int r, int n, int dBig, int rBig, int dSmall, int rSmall, COLORREF colFill, int wLine, COLORREF colLine, double angle, int nText, CString strText[], int spacing[], int hFont, COLORREF colText)
{
	int prevMode = SetGraphicsMode(pDC->m_hDC, GM_ADVANCED);
	XFORM xFormOld;
	pDC->GetWorldTransform(&xFormOld);
	Translate(pDC, 3.5*r, 1.5*r, false);
	Rotate(pDC, angle, false);
	DrawFilmReel(pDC, r, n, dBig, rBig, dSmall, rSmall, colFill, wLine, colLine);
	//Fontovi
	CFont font;
	//Moram da se vratim nazad neke transformacije
	Rotate(pDC, -angle, false); // vracam ugao da bih tekst ispisao pravo, a ne pod angle uglom, jer sam gore izvrsio rotaciju za ugao angle kod kotura
	font.CreateFont(hFont, 0, 0, 0, FW_BOLD, 100, 0, 0, 0, 0, 0, 0, 0, _T("Tahoma")); //kreiram font prema tekstu zadatka
	CFont* stariFont = pDC->SelectObject(&font);
	pDC->SetTextColor(colText); 
	pDC->SetBkMode(TRANSPARENT); //Ovo moze i ne mora, cisto da tekst nema svoju pozadinu (pravougaonik)
	pDC->SetTextAlign(TA_RIGHT); //ravnam u desno
	double baseX = -1.2*r; // desna ivica teksta je na -1.2*r udaljenosti, levo od centra kotura u koji sam vec pozicioniran
	int currentY = -r; // ravnam se sa gornjom ivicom kotura, ja sam trenutno u centru kotura, samo se vratim za poluprecnik do gornje ivice
	for (int i = 0; i < nText; ++i)
	{
		pDC->TextOut((int)baseX, currentY, strText[i]);
		currentY += spacing[i];   
	}
	// Filmska traka (bezier kriva), nije bas najsrecnije
	CPen* bezierOlovka = new CPen(PS_SOLID, wLine, colLine);
	CPen* staraOlovka = pDC->SelectObject(bezierOlovka);
	//Moram bre da vratim transformacije bre, majmune
	Translate(pDC, -3.5 * r, r - 0.25 * r, false);
	Rotate(pDC, -angle, false);
	double yKoordinataNeparnihTacaka = r + 0.25 * r;
	//Za tacku jedan i dva koristim formulu kruznice za kruznicu sa centrom u tackama x0,y0: (x-x0)^2+(y-y0)^2=r^2, x i y su tacke koje trazim, u ovom slucaju samo x 
	double xKoordinataPrveTacke = 245; //uradjena jednacina
	double xKoordinataDrugeTacke = xKoordinataPrveTacke - 0.25 * r;
	double xKoordinataTreceTacke = xKoordinataDrugeTacke - ((xKoordinataPrveTacke - xKoordinataDrugeTacke) * 0.8);
	double xKoordinataCetvrteTacke = xKoordinataTreceTacke - ((xKoordinataDrugeTacke - xKoordinataTreceTacke) * 0.8);
	double xKoordinataPeteTacke = xKoordinataCetvrteTacke - ((xKoordinataTreceTacke - xKoordinataCetvrteTacke) * 0.8);
	double xKoordinataSesteTacke = xKoordinataPeteTacke - ((xKoordinataCetvrteTacke - xKoordinataPeteTacke) * 0.8);
	double xKoordinataSedmeTacke = xKoordinataSesteTacke - ((xKoordinataPeteTacke - xKoordinataSesteTacke) * 0.8);
	POINT tacke[7] = { CPoint(xKoordinataSedmeTacke , yKoordinataNeparnihTacaka), CPoint(xKoordinataSesteTacke ,yKoordinataNeparnihTacaka - 0.15 * r), CPoint(xKoordinataPeteTacke ,yKoordinataNeparnihTacaka), CPoint(xKoordinataCetvrteTacke , yKoordinataNeparnihTacaka + 0.10 * r), CPoint(xKoordinataTreceTacke ,yKoordinataNeparnihTacaka), CPoint(xKoordinataDrugeTacke ,yKoordinataNeparnihTacaka - 0.05 * r), CPoint(xKoordinataPrveTacke ,yKoordinataNeparnihTacaka) };
	pDC->PolyBezier(tacke, 7);

	// Vrati stare objekte
	pDC->SelectObject(staraOlovka);
	pDC->SelectObject(&stariFont);
	pDC->SetWorldTransform(&xFormOld); // vraca koordinatni pocetak gde je bio pre transformacije
	pDC->SetGraphicsMode(prevMode);
	delete bezierOlovka;
}

void CSeptembar2023View::Save(CDC* pDC, CRect rcDC, CRect rcBmp, CString sFile)
{
	//Ovo pojma nemam
}

void CSeptembar2023View::OnDraw(CDC* pDC)
{
	CSeptembar2023Doc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
	//Tekst izdvojen na reci
	CString lines[3];
	lines[0] = _T("FILMSKI");
	lines[1] = _T("SUSRET");
	lines[2] = _T("NIŠ");

	int spacing[2] = { 40, 170 }; // razmaci izmedju redova, razmaci izmedju donje ivice prethodne, i gornje ivice sledece reci
	//40 je razmak izmedju donje ivice reci FILMSKI i gornje ivice reci SUSRET
	//170 je razmak izmedju donje ivice reci SUSRET, i gornje ivice reci NIS
	DrawFilmReel(pDC, 100, 6, 63, 25, 20, 10, RGB(125, 125, 125), 3, RGB(0, 0, 0), PI/6, 3, lines, spacing, 50, RGB(0, 0, 0));
}


// CSeptembar2023View printing

BOOL CSeptembar2023View::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CSeptembar2023View::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CSeptembar2023View::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CSeptembar2023View diagnostics

#ifdef _DEBUG
void CSeptembar2023View::AssertValid() const
{
	CView::AssertValid();
}

void CSeptembar2023View::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CSeptembar2023Doc* CSeptembar2023View::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CSeptembar2023Doc)));
	return (CSeptembar2023Doc*)m_pDocument;
}
#endif //_DEBUG


// CSeptembar2023View message handlers
