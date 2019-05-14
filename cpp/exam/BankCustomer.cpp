using namespace std; 


class BankCustomer
{
    private: 
        string name;
        long money;
    
    public:
        BankCustomer(string name)
        {}

        BankCustomer(const BankCustomer &bc)
        {
            this.name = bc.name;
            this.money = bc.money;
        }

        BankCustomer operator=(const BankCustomer& bc)
        {
            this.name = bc.name;
            this.money = bc.money;
        }

        bool operator==(const BankCustomer& bc)
        {
            return this.name == bc.name && this.money == bc.money;
        }

        BankCustomer operator+(const BankCustomer& bc)
        {
            this.money += bc.money;
        }
}
