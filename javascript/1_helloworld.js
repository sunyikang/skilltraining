
console.log(1 === 2);
console.log(1 === 1);
console.log(1 === "1");
console.log(1 == "1");

{
	var arr = [1, 2, 3];

	var a1 = arr.pop();
	console.log(a1);

	var a2 = arr.slice();
	console.log(a2);

	a2 = 9;
	console.log(a2);

	a2 = arr;
	console.log(a2);

	a2[0] = 99;
	console.log(a2);


	// var a = 2;
	// var b = a;
	// b = 1;
	// console.log(a);
}


{
	console.log("hello world");

	//var other = prompt("Please enter your name", "Harry Potter");

	var num = -12;
	console.log(Math.random());

	var object = {};
	object['a'] = 9;
	object[4] = 8;
	object['4'] = 5;
	var x = 'a';
	object[x] = 6;

	console.log(object);

	for(var k in object)
	{
		console.log(k);
	}	
}


{
	var array = [1,2,3,'ss'];
	array.push("fdfaf");
	var pop = array.pop();
	console.log(array);
	console.log(array.length);
	console.log(pop);

	// for(var i = 0; i < array.length; i++)
	// {
	// 	console.log(array[i]);
	// }
	for(var k in array)
	{
		console.log("array " + k);
	}

}


{
	var fun = function(father, mother)
	{
		return father + " " + mother;
	}

	console.log(fun("yikang", "rongzhu"));
}


{
	var convertor = function() {}

	convertor[0] = "apple";
	convertor[1] = "pear";
	for(var k in convertor)
	{
		console.log(convertor[k]);
	}
	console.log(convertor);
}

{
	var print = function()
	{
		console.log("printing...");
		return 1;
	}
	console.log(print());
}

{
	var many = function(p1, p2, p3)
	{
		console.log(arguments);
	}

	many("ruotian", "bohao");
	many("ape", "piku", "gaga");
	many("mono");
}


{
	var printlate = function(input)
	{
		console.log(input);
	}
	setTimeout(
		function(){
			printlate('print after 1 second')
		}
		, 1000);
}


