{

	var o = [1];
	console.log(o.constructor);

	function Tree(name)
	{
		this.name = name;
	}

	var thetree = new Tree("a tree");
	console.log(thetree.constructor);

	console.log(thetree.constructor == Tree);


	var a = new String("c");
	var b = new String("d");
	console.log(a.constructor, a.constructor == b.constructor);

	var c = a.constructor("e");
	console.log(c);

	console.log(String.proto);

	function Fee() {
	  // ...
	}

	function Fi() {
	  // ...
	}
	Fi.prototype = new Fee();

	function Fo() {
	  // ...
	}
	Fo.prototype = new Fi();

	function Fum() {
	  // ...
	}
	Fum.prototype = new Fo();

	var fum = new Fum();
	// ...

	if (Fi.prototype.isPrototypeOf(fum)) {
	  // do something safe
	  console.log(fum);
	}
}