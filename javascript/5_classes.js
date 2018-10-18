function Shape() {
    this.x = 0;
    this.y = 0;
    console.log("hello shape");
}

Shape.prototype = {
    move: function(x, y) {
        this.x += x;
        this.y += y;
    }
}

function Rectangle() {
    Shape.call(this);
    this.x = 1;
    this.y = 1;
    console.log('hello Rectangle');
}

Rectangle.prototype = new Shape();

var x = new Rectangle();