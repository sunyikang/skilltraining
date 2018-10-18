puts "Hello world!"

def hello()
end

class Dog
    def name
        # puts 'assign value to name'
        return @name
    end
end


joey = Dog.new 
puts "#{joey.name}"
puts "done"