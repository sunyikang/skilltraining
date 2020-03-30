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
    : m_owner(owner)
    {
        m_type = type;
        m_name = name;
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
        this->m_pet = make_shared<Pet>(this, petType, petName);
    }

private:
    string m_name;
    shared_ptr<Pet> m_pet;
};

void PrettyPrint(const Owner& owner)
{}

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
