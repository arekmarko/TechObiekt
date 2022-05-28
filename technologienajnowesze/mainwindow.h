#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include <QTableView>
#include <QMainWindow>
#include "tabela.h"
#include "otworz.h"
#include "ui_mainwindow.h"
#include "zapisz.h"
#include "drawwidget.h"

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
namespace Okno { class Tabela; }

QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
public slots:
     void dodaj();


//signals:
//    void dodajj();
private slots:
    void on_pushButton_clicked();

    void on_pushButton_5_clicked();

    void on_pushButton_4_clicked();


private:
    Ui::MainWindow *ui;
    tabela *Tabela;
    otworz *Otworz;
    zapisz *Zapisz;
    QPoint *p1, *p2;

    QTableView *table;

};
#endif // MAINWINDOW_H
