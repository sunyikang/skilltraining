var Queue = function() {
    // Hey! Rewrite in the new style. Your code will wind up looking very similar,
    // but try not not reference your old code in writing the new style.

    this._storage = {};
    this._start = 0;
    this._end = 0;
};

Queue.prototype.enqueue = function(value) {
    this._storage[this._end++] = value;
};

Queue.prototype.dequeue = function() {
    if (this._start < this._end) {
        var value = this._storage[this._start];
        delete this._storage[this._start];
        this._start++;
        return value;
    }
    return null;
};

Queue.prototype.size = function() {
    return this._end - this._start;
};