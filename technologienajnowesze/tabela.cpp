#include "ui_tabela.h"
#include <QVBoxLayout>
#include <QPushButton>
#include <QCheckBox>
#include <QTextEdit>
#include <QTableView>
#include "mainwindow.h"
#include "tabela.h"
#include <QTableWidget>


tabela::tabela(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::tabela)
{
    ui->setupUi(this);
    QObject::connect(
    ui->pushButton, &QPushButton::clicked,
             this, &tabela::onAddWidget
                );
   //QObject::connect(ui->pushButton_2, &QPushButton::clicked,this, &MainWindow::dodaj);

}

tabela::~tabela()
{
    delete ui;
}


void tabela::onAddWidget()
{
   QVBoxLayout* layout= qobject_cast<QVBoxLayout*>( ui->verticalLayoutWidget->layout());
   QHBoxLayout* newLayout= new QHBoxLayout(ui->verticalLayoutWidget);

   QString buttonText= tr("usun");//.arg(layout->count());
    QPushButton* button = new QPushButton(buttonText, ui->verticalLayoutWidget);
    button->setMaximumSize(50,50);
    layout->insertWidget(0, button);


    QTextEdit* textEdit = new QTextEdit(ui->verticalLayoutWidget);
    newLayout->addWidget(textEdit);
    textEdit->setMaximumSize(70,30);
    textEdit->setPlaceholderText("nazwa");

    QTextEdit* textEdit2 = new QTextEdit(ui->verticalLayoutWidget);
    newLayout->addWidget(textEdit2);
    textEdit2->setMaximumSize(70,30);
    textEdit2->setPlaceholderText("typ");

    QCheckBox* checkBox = new QCheckBox("klucz glowny", ui->verticalLayoutWidget);
    newLayout->addWidget(checkBox);
    layout->insertLayout(0, newLayout);

    mButtonToLayoutMap.insert(button, newLayout);

    QObject::connect(
                button, &QPushButton::clicked,
                this, &tabela::onRemoveWidget
                );
}

void tabela::onRemoveWidget()
{


    QPushButton* button= qobject_cast<QPushButton*>(sender());
    QHBoxLayout* layout = mButtonToLayoutMap.take(button);
    while (layout->count() !=0)
    {
           QLayoutItem* item = layout->takeAt(0);
           delete item->widget();

           delete item;


    }

delete layout;
   delete button;

}
void tabela::on_textEdit_2_textChanged()
{

}


void tabela::on_pushButton_clicked()
{


}

void tabela::on_pushButton_2_clicked()
{
emit buttonPressed();
}

