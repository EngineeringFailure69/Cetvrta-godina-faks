#include "StdAfx.h"
#include "GLRenderer.h"
#include "GL\gl.h"
#include "GL\glu.h"
#include "GL\glaux.h"
#include "GL\glut.h"
//#pragma comment(lib, "GL\\glut32.lib")

#define RAD(a) (3.14159265358979323846*a/180)
#define PI 3.14159265358979323846
#define toRad PI / 180

CGLRenderer::CGLRenderer(void)
{
	m_hrc = NULL;
	this->viewR = 12;

	this->viewAngleXY = 12;
	this->viewAngleXZ = 0;

	eyex = 0, eyey = 0, eyez = 0;
	centerx = 0, centery = 0, centerz = 0;
	upx = 0, upy = 0, upz = 0;

	this->CalculatePosition();
}

CGLRenderer::~CGLRenderer(void)
{
}

bool CGLRenderer::CreateGLContext(CDC* pDC)
{
	PIXELFORMATDESCRIPTOR pfd ;
   	memset(&pfd, 0, sizeof(PIXELFORMATDESCRIPTOR));
   	pfd.nSize  = sizeof(PIXELFORMATDESCRIPTOR);
   	pfd.nVersion   = 1; 
   	pfd.dwFlags    = PFD_DOUBLEBUFFER | PFD_SUPPORT_OPENGL | PFD_DRAW_TO_WINDOW;   
   	pfd.iPixelType = PFD_TYPE_RGBA; 
   	pfd.cColorBits = 32;
   	pfd.cDepthBits = 24; 
   	pfd.iLayerType = PFD_MAIN_PLANE;
	
	int nPixelFormat = ChoosePixelFormat(pDC->m_hDC, &pfd);
	
	if (nPixelFormat == 0) return false; 

	BOOL bResult = SetPixelFormat (pDC->m_hDC, nPixelFormat, &pfd);
  	
	if (!bResult) return false; 

   	m_hrc = wglCreateContext(pDC->m_hDC); 

	if (!m_hrc) return false; 

	return true;	
}

void CGLRenderer::PrepareScene(CDC *pDC)
{
	wglMakeCurrent(pDC->m_hDC, m_hrc);
	{
		glClearColor(0.502, 0.753, 1.0, 1.0);
	}
	wglMakeCurrent(NULL, NULL);
}

void CGLRenderer::DrawScene(CDC *pDC)
{
	wglMakeCurrent(pDC->m_hDC, m_hrc);
	{
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		glLoadIdentity();

		gluLookAt(eyex, eyey, eyez,
			centerx, centery, centerz,
			upx, upy, upz);

		glScaled(0.75, 0.75, 0.75);
		glTranslated(0, -3.33, 0);
		DrawAxis(100);

		glPushMatrix();
		{
			double gridsize = 10;
			glTranslated(-gridsize / 2, 0, -gridsize / 2);
			DrawGrid(gridsize, gridsize, 10, 10);
		}
		glPopMatrix();

		glPushMatrix();
		{
			DrawFigure(this->angle);
		}
		glPopMatrix();


	}
	glFlush();
	SwapBuffers(pDC->m_hDC);
	wglMakeCurrent(NULL, NULL);
}

void CGLRenderer::Reshape(CDC *pDC, int w, int h)
{
	wglMakeCurrent(pDC->m_hDC, m_hrc);
	{
		glViewport(0, 0, w, h);
		glMatrixMode(GL_PROJECTION);
		glEnable(GL_DEPTH_TEST);
		glLoadIdentity();
		gluPerspective(40, (double)w / h, 1, 100);
		glMatrixMode(GL_MODELVIEW);
	}
	wglMakeCurrent(NULL, NULL);
}

void CGLRenderer::DestroyScene(CDC *pDC)
{
	wglMakeCurrent(pDC->m_hDC, m_hrc);
	// ... 
	wglMakeCurrent(NULL,NULL); 
	if(m_hrc) 
	{
		wglDeleteContext(m_hrc);
		m_hrc = NULL;
	}
}

void CGLRenderer::DrawSphere(double r, int nSegAlpha, int nSegBeta)
{

	// sfera se crta iz centra!!!
	// zbog optimizacije crtanja alpha postaje beta

	int alphaStep = 360 / nSegAlpha;
	int betaStep = 360 / nSegBeta;


	glBegin(GL_QUAD_STRIP);
	{
		for (int beta = betaStep; beta <= 180; beta += betaStep) {
			for (int alpha = 0; alpha <= 360; alpha += alphaStep) {

				double x1 = r * cos(RAD(alpha)) * cos(RAD(beta));
				double y1 = r * sin(RAD(alpha));
				double z1 = r * cos(RAD(alpha)) * sin(RAD(beta));

				double x2 = r * cos(RAD(alpha)) * cos(RAD(beta) + RAD(betaStep));
				double y2 = r * sin(RAD(alpha));
				double z2 = r * cos(RAD(alpha)) * sin(RAD(beta) + RAD(betaStep));

				glVertex3d(x1, y1, z1);
				glVertex3d(x2, y2, z2);
			}
		}
	}
	glEnd();
}

void CGLRenderer::DrawCylinder(double h, double r1, double r2, int nSeg)
{
	int alphaStep = 360 / nSeg;
	glBegin(GL_TRIANGLE_FAN);
	{
		glVertex3d(0, h, 0);

		for (int alpha = 0; alpha <= 360; alpha += alphaStep) {

			double x = r1 * cos(RAD(alpha));
			double z = r1 * sin(RAD(alpha));

			glVertex3d(x, h, z);
		}
	}
	glEnd();

	glBegin(GL_TRIANGLE_FAN);
	{
		glVertex3d(0, 0, 0);

		for (int alpha = 0; alpha <= 360; alpha += alphaStep) {

			double x = r2 * cos(RAD(alpha));
			double z = r2 * sin(RAD(alpha));

			glVertex3d(x, 0, z);
		}
	}
	glEnd();

	glBegin(GL_QUAD_STRIP);
	{
		for (int alpha = 0; alpha <= 360; alpha += alphaStep) {
			double x1 = r1 * cos(RAD(alpha));
			double z1 = r1 * sin(RAD(alpha));

			double x2 = r2 * cos(RAD(alpha));
			double z2 = r2 * sin(RAD(alpha));

			glVertex3d(x1, h, z1);
			glVertex3d(x2, 0, z2);
		}
	}
	glEnd();
}

void CGLRenderer::DrawCone(double h, double r, int nSeg)
{
	int alphaStep = 360 / nSeg;
	glBegin(GL_TRIANGLE_FAN);
	{
		glColor3d(DEO_KAKTUSA);
		glVertex3d(0, h, 0);

		for (int alpha = 0; alpha <= 360; alpha += alphaStep) {
			double x = r * cos(RAD(alpha));
			double z = r * sin(RAD(alpha));

			glVertex3d(x, 0, z);
		}
	}
	glEnd();

	glBegin(GL_TRIANGLE_FAN);
	{
		glVertex3d(0, 0, 0);

		for (int alpha = 0; alpha <= 360; alpha += alphaStep) {

			double x = r * cos(RAD(alpha));
			double z = r * sin(RAD(alpha));

			glVertex3d(x, 0, z);
		}
	}
	glEnd();
}

void CGLRenderer::DrawAxis(double width)
{
	glLineWidth(1);
	glPointSize(10);

	glBegin(GL_LINES);
	{
		glColor3d(1, 0, 0);
		glVertex3d(0, 0, 0);
		glVertex3d(width, 0, 0);

		glColor3d(0, 1, 0);
		glVertex3d(0, 0, 0);
		glVertex3d(0, width, 0);

		glColor3d(0, 0, 1);
		glVertex3d(0, 0, 0);
		glVertex3d(0, 0, width);
	}
	glEnd();
}

void CGLRenderer::DrawGrid(double width, double height, int nSegW, int nSegH)
{
	double wStep = width / nSegW;
	double hStep = height / nSegH;

	glBegin(GL_LINES);
	{
		glColor3d(1.0, 1.0, 1.0);
		for (double w = 0; w <= width; w += wStep) {
			glVertex3d(w, 0, 0);
			glVertex3d(w, 0, height);
		}
		for (double h = 0; h <= height; h += hStep) {
			glVertex3d(0, 0, h);
			glVertex3d(width, 0, h);
		}
	}
	glEnd();
}

void CGLRenderer::DrawFigure(double angle)
{
	// definicija dimenzija

	// vaza

	float r1DonjeSaksije = 1, r2DonjeSaksije = 1.25, hSaksije = 1.25;
	float rGornjeSaksije = 1.5, hGornjeSaksije = 0.5;

	// kaktus

	float rVecegKaktusa = 0.5, hVecegKaktusa = 1.4;

	float rManjegKaktusa = 0.4, hManjegKaktusa = 1.4;

	float rSfere = 0.33;

	float rKupe = 0.4, hKupe = 1.4;


	// crtanje

	glColor3f(0.827, 0.494,0.156);

	DrawCylinder(hSaksije, r2DonjeSaksije, r1DonjeSaksije, 8);
	glTranslatef(0, hSaksije, 0);
	DrawCylinder(hGornjeSaksije, rGornjeSaksije, rGornjeSaksije, 8);
	glTranslatef(0, hGornjeSaksije, 0);

	glColor3f(DEO_KAKTUSA);
	DrawCylinder(hVecegKaktusa, rVecegKaktusa, rVecegKaktusa, 100);
	
	glTranslatef(0, hVecegKaktusa + rSfere, 0);
	glColor3f(SFERA);
	DrawSphere(rSfere, 100, 100);


	// leva grana
	glPushMatrix();
	{
		glRotatef(45, 1, 0, 0);
		glColor3f(DEO_KAKTUSA);
		glTranslatef(0, rSfere, 0);
		DrawCylinder(hManjegKaktusa, rManjegKaktusa, rManjegKaktusa, 100);

		glTranslatef(0, hManjegKaktusa + rSfere, 0);
		glColor3f(SFERA);
		DrawSphere(rSfere, 100, 100);

		glTranslatef(0, rSfere, 0);
		glColor3f(DEO_KAKTUSA);
		DrawCone(hKupe, rKupe, 100);

		glTranslatef(0, hKupe + rSfere, 0);
		glColor3f(SFERA);
		DrawSphere(rSfere, 100, 100);

	}
	glPopMatrix();

	// srednja grana

	glPushMatrix();
	{
		glColor3f(DEO_KAKTUSA);
		glTranslatef(0, rSfere, 0);
		DrawCylinder(hManjegKaktusa, rManjegKaktusa, rManjegKaktusa, 100);

		glTranslatef(0, hManjegKaktusa + rSfere, 0);
		glColor3f(SFERA);
		DrawSphere(rSfere, 100, 100);

		// srednje leva

		glPushMatrix();
		{
			glRotatef(45 + angle, 1, 0, 0);
			glColor3f(DEO_ZA_ROTIRANJE);
			glTranslatef(0, rSfere, 0);
			DrawCylinder(hManjegKaktusa, rManjegKaktusa, rManjegKaktusa, 100);

			glTranslatef(0, hManjegKaktusa + rSfere, 0);
			glColor3f(SFERA);
			DrawSphere(rSfere, 100, 100);

			glTranslatef(0, rSfere, 0);
			glColor3f(DEO_KAKTUSA);
			DrawCone(hKupe, rKupe, 100);

			glTranslatef(0, hKupe + rSfere, 0);
			glColor3f(SFERA);
			DrawSphere(rSfere, 100, 100);
		}
		glPopMatrix();

		// srednje desna

		glPushMatrix();
		{
			glRotatef(-45, 1, 0, 0);
			glColor3f(DEO_KAKTUSA);
			glTranslatef(0, rSfere, 0);
			DrawCylinder(hManjegKaktusa, rManjegKaktusa, rManjegKaktusa, 100);

			glTranslatef(0, hManjegKaktusa + rSfere, 0);
			glColor3f(SFERA);
			DrawSphere(rSfere, 100, 100);

			glTranslatef(0, rSfere, 0);
			glColor3f(DEO_KAKTUSA);
			DrawCylinder(hManjegKaktusa, rManjegKaktusa, rManjegKaktusa, 100);

			glTranslatef(0, hManjegKaktusa + rSfere, 0);
			glColor3f(SFERA);
			DrawSphere(rSfere, 100, 100);
		}
		glPopMatrix();
	}
	glPopMatrix();

	// desna grana

	glPushMatrix();
	{
		glRotatef(-45, 1, 0, 0);
		glColor3f(DEO_KAKTUSA);
		glTranslatef(0, rSfere, 0);
		DrawCylinder(hManjegKaktusa, rManjegKaktusa, rManjegKaktusa, 100);

		glTranslatef(0, hManjegKaktusa + rSfere, 0);
		glColor3f(SFERA);
		DrawSphere(rSfere, 100, 100);

		glTranslatef(0, rSfere, 0);
		glColor3f(DEO_KAKTUSA);

		DrawCone(hKupe, rKupe, 100);

		glTranslatef(0, hKupe + rSfere, 0);
		glColor3f(SFERA);
		DrawSphere(rSfere, 100, 100);

		glTranslatef(0, rSfere, 0);
		glColor3f(DEO_KAKTUSA);

		DrawCone(hKupe, rKupe, 100);

		glTranslatef(0, hKupe + rSfere, 0);
		glColor3f(SFERA);
		DrawSphere(rSfere, 100, 100);
		
	}
	glPopMatrix();
}

void CGLRenderer::CalculatePosition()
{
	double dWXY = viewAngleXY * PI / 180,
		   dWXZ = viewAngleXZ * PI / 180;

	eyex = viewR * cos(dWXY) * cos(dWXZ);
	eyey = viewR * sin(dWXY);
	eyez = viewR * cos(dWXY) * sin(dWXZ);

	upy = signbit(cos(dWXY)) ? -1 : 1;
}

void CGLRenderer::RotateView(double dXY, double dXZ)
{
	viewAngleXY += dXY;
	viewAngleXY = min(90, viewAngleXY);
	viewAngleXY = max(-90, viewAngleXY);

	viewAngleXZ += dXZ;
	CalculatePosition();
}

