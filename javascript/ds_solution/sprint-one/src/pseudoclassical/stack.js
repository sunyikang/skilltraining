var Stack = function()
{
    this._storage = {};
    this._size = 0;
};


Stack.prototype.push = function(value)
{
    this._storage[this._size++] = value;
};

Stack.prototype.pop = function()
{
    if(this._size > 0)
    {
        var value = this._storage[this._size - 1];
        delete this._storage[this._size - 1];
        this._size --;
        return value;
    }
    return null;
};

Stack.prototype.size = function()
{
    return this._size;
};
