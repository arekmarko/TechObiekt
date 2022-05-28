#ifndef ZAPISZ_H
#define ZAPISZ_H

#include <QDialog>

namespace Ui {
class zapisz;
}

class zapisz : public QDialog
{
    Q_OBJECT

public:
    explicit zapisz(QWidget *parent = nullptr);
    ~zapisz();

private:
    Ui::zapisz *ui;

};

#endif // ZAPISZ_H
