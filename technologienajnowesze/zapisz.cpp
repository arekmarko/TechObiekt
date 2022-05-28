#include "zapisz.h"
#include "ui_zapisz.h"
#include <QFileDialog>
zapisz::zapisz(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::zapisz)
{
    ui->setupUi(this);
}

zapisz::~zapisz()
{
    delete ui;
}



