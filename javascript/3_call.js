// .call #1. Using call to chain constructors for an object
{
	function Product(name, price) 
	{
		this.name = name;
		this.price = price;

		if (price < 0) 
		{
			throw RangeError('Cannot create product ' +
		              this.name + ' with a negative price');
		}
	}

	function Food(name, price) {
		Product.call(this, name, price);
		this.category = 'food';
	}

	function Toy(name, price) {
		Product.call(this, name, price);
		this.category = 'toy';
	}

	var cheese = new Food('feta', 5);
	var fun = new Toy('robot', 40);

	console.log(cheese);
	console.log(fun);
}

// .call #2. Using call to invoke a function and specifying the context for 'this'
{
	function greet() {
	  var reply = [this.person, 'Is An Awesome', this.role].join(' ');
	  console.log(reply);
	}

	var i = {
	  person: 'Douglas Crockford', role: 'Javascript Developer'
	};

	greet.call(i); // Douglas Crockford Is An Awesome Javascript Developer
}

// .call #3. Using call to invoke an anonymous function
{
	var animals = [
	  { species: 'Lion', name: 'King' },
	  { species: 'Whale', name: 'Fail' }
	];

	for (var i = 0; i < animals.length; i++) {
	  (
	  	function(i) {
		    this.print = function() {
		      console.log('#' + i + ' ' + this.species
		                  + ': ' + this.name);
		    }
		    this.print();
		  }
		  ).call(animals[i], i+1);
	}
}
