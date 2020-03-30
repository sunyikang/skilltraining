
class Boo{};

class Foo : public Boo{};

int main()
{
    Boo* b1 = new Foo();
    delete b1;
    return 0;
}
