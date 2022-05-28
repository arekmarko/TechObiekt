#include "otworz.h"
#include "ui_otworz.h"

otworz::otworz(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::otworz)
{
    ui->setupUi(this);
}

otworz::~otworz()
{
    delete ui;
}
