#include <iostream>
#include <vector>
#include <memory>
#include <string>
using namespace std;

class Owner;

class Pet
{
public:
    enum EType { Mouse, Cat };

    Pet(Owner& owner, EType type, string name)
    : m_owner(owner), m_type(type), m_name(name)
    {
    }
    
    string getText()
    {
        string text;

        if (m_type == EType::Mouse) {
            text += "mouse";
        } else {
            text += "cat";
        }

        text += " named ";
        text += m_name;
        return text;
    }

private:
    Owner &m_owner;
    EType m_type;
    string m_name;
};

class Owner
{
public:
    Owner(string name, Pet::EType petType, string petName) 
    {
        this->m_name = name;
        this->m_pet = make_shared<Pet>((*this), petType, petName);
    }

    void PrettyPrint() const
    {
        cout << "My name is " << m_name << " and I own a " << m_pet->getText() << "\n";
    }

private:
    string m_name;
    shared_ptr<Pet> m_pet;
};

void PrettyPrint(const Owner& owner)
{
    owner.PrettyPrint();
}

int main()
{
    vector<Owner> ownerList;
    ownerList.push_back(Owner("Jack", Pet::EType::Mouse, "Jerry"));
    ownerList.push_back(Owner("Jill", Pet::EType::Cat, "Tom"));

    for(const auto& owner : ownerList)
    {
        PrettyPrint(owner);
    }

    return 0;
}
