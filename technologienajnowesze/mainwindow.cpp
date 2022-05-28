#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "tabela.h"
#include <QTextEdit>
#include <QMdiArea>
#include <QSize>
#include <QTableView>
#include "tabela.h"
#include "otworz.h"
#include <QIODevice>
#include <QFile>
#include <QFileDialog>
#include <QPoint>
#include <QWidget>
#include <QWidgetAction>
#include "paintwidget.h"
#include <QHBoxLayout>
MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)

{
    ui->setupUi(this);
}


MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_pushButton_clicked()
{
Tabela= new tabela(this);
QObject::connect(Tabela, SIGNAL(buttonPressed()), this, SLOT(dodaj()));
Tabela->setMinimumSize(550,400);
Tabela->setMaximumSize(550,400);
Tabela->show();



}


void MainWindow::on_pushButton_5_clicked()
{

    QString fileContent;
    QString filename= QFileDialog::getOpenFileName(this, "Choose File");
   if(filename.isEmpty())
       return;

   QFile file(filename);

   if (!file.open(QIODevice::ReadWrite | QIODevice::Text))
       return;
   QTextStream in(&file);
   fileContent= in.readAll();
   file.close();


}


void MainWindow::on_pushButton_4_clicked()
{

    //Save File

       QString filename= QFileDialog::getSaveFileName(this, "Save As");

       if (filename.isEmpty())
           return;

       QFile file(filename);


       //Open the file
       if (!file.open(QIODevice::WriteOnly | QIODevice::Text))
           return;

       QTextStream out(&file);
       file.close();


}
void MainWindow::dodaj()
{

         QTableView* table = new QTableView;
         ui->mdiArea->addSubWindow(table);
         table->show();


}






