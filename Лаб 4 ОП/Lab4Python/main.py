from Operations import *
from MovingPointParticle import *

k = input_number("k")
n = input_number("n")

point_x_array = []
for i in range(k):
    point_x_array.append(MovingPointParticleX())

point_xy_array = []
for i in range(n):
    point_xy_array.append(MovingPointParticleXY())

print("\nGenerated objects in x_array: ")
show_objects(point_x_array)

print("\nGenerated objects in xy_array: ")
show_objects(point_xy_array)

print()
t = input_time()

print("\nX and Y coordinates of objects in xArray: ")
show_coordinates(point_x_array, t)

print("\nX and Y coordinates of objects in xyArray: ")
show_coordinates(point_xy_array, t)

max_distance_x, first_x, second_x = return_max_distance(point_x_array)
print(f"\nMax distance in x_array is {round(max_distance_x, 3)} (between {first_x + 1}) and {second_x + 1}) points)")

max_distance_xy, first_xy, second_xy = return_max_distance(point_xy_array)
print(f"Max distance in xy_array is {round(max_distance_xy, 3)} (between {first_xy + 1}) and {second_xy + 1}) points)")
