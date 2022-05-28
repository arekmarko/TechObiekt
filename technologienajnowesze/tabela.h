#ifndef TABELA_H
#define TABELA_H

#include <QDialog>
#include <QHBoxLayout>
#include <QTextEdit>
#include <QTableView>
namespace Ui {
class tabela;
}

class tabela : public QDialog
{
    Q_OBJECT

public:
    explicit tabela(QWidget *parent = nullptr);
    ~tabela();
void onAddWidget();
void onRemoveWidget();
signals:
void buttonPressed();
public slots:
 void on_pushButton_2_clicked();

private slots:
    void on_textEdit_2_textChanged();

    void on_pushButton_clicked();

private:

    Ui::tabela *ui;
    QHash<QPushButton*, QHBoxLayout*> mButtonToLayoutMap;
    QHash<QPushButton*, QTextEdit*> nButtonToLayoutMap;
    tabela* d;
    QTableView* table;


};

#endif // TABELA_H
