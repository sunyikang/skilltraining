var Stack = function() {
    // Hey! Rewrite in the new style. Your code will wind up looking very similar,
    // but try not not reference your old code in writing the new style.

    var instance = Object.create(stackMethods);

    instance._storage = {};
    instance._size = 0;

    return instance;
};

var stackMethods = {};

stackMethods.push = function(value) {
    this._storage[this._size++] = value;
};

stackMethods.pop = function() {
    if (this._size > 0) {
        var value = this._storage[this._size - 1];
        delete this._storage[this._size - 1];
        this._size--;
        return value;
    }
    return null;
};

stackMethods.size = function() {
    return this._size;
};