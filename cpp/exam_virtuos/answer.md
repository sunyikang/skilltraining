
## 1.1

B "is a" A.
```
class A
{
	int data;
};
 
class B : class A
{
};
```


B "has a" A.
```
class A
{
	int data;
};
 
class B
{
	A obj; //object of A as a member of B
};
```


## 1.4 
What is the difference between the stack and heap? When should we prefer one over the
other?

Answer:

Stack is used for static memory allocation and Heap for dynamic memory allocation, both stored in the computer's RAM . Variables allocated on the stack are stored directly to the memory and access to this memory is very fast, and it's allocation is dealt with when the program is compiled.

When use small data, we use stack. 
When use big data (bigger enough then static memory cannot hold), we use heap.


## 2.1

What is the difference between a vertex shader and pixel shader? Explain what each one
does.

Vertex shader work on attributes of vertices, which are polygons.
Pixel shader work on color, brightness, contrast, and other characteristics of a single pixel (fragment)


Given a texture of size 1024x1024 that is loaded into memory, what is the size in MB that
is used?

Answer: Assump a pixel is 1 bit.  Then it is 1024x1024 bit. That is 1 MB.

What is the inverse of an Orthogonal matrix?

Answer:  The T (transpose) of Orthogonal matrix

## 2.2

State 3 methods to optimize rendering. For each method, briefly explain how it works.

Answer:  
1) don't render the object that out of view.   Define a scope of view, and cut the rest of part.
2) don't render the back side of a object.   Eye point to object is a vector, together with each pologon normal, can computer whether the pologon in object is in the back side.
3) use low pologon level to render the object.  The less pologons a object has, the less time to do render.

## 2.3

What is a transform matrix in graphics and what are the 3 major components that make
it?

The matrix that can change a object in space level (2D or 3D). Major components:  Transation / Rotation / Scale Transfromation matrix.


Describe the steps and operations you would need to convert a model’s vertices to a
pixel position.

1) change the model from local matrix to global matrix by transform matrix
2) change to viewport
3) cut the part that out of viewport

## 2.4

What is BRDF? Highlight the 4 major parameters in BRDF and what they represent.

Answer:

http://graphics.stanford.edu/~smr/cs348c/surveypaper.html
1) bidirectional reflectance distribution function
2) angular: 
	angle between incoming ray and normal, 
	angle between outgoing ray and normal, 
	angle between incoming ray on surface and normal, 
	angle between outgoing ray on surface and normal


What is meant by Physically Based Rendering and what does it allow us to do?

Answer:

Physically-Based Rendering (PBR) is an approach for materials and rendering that creates more accurate and predictable results than previous game rendering techniques.

Allow us to do dynamic lighting conditions (e.g. time-of-day).
