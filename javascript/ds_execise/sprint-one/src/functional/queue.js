var Queue = function() {
  var someInstance = {};

  // Use an object with numeric keys to store values
  var storage = {};

  // Implement the methods below

  var start = 0;
  var end = 0;

  someInstance.enqueue = function(value) {
    storage[end++] = value;
  };

  someInstance.dequeue = function() {

    if(start < end){
      var value = storage[start];
      delete storage[start];
      start ++;
      return value;
    }
  };

  someInstance.size = function() {

    return end - start;
  };

  return someInstance;
};
