def input_time():
    time = float(input("Enter t in seconds: "))
    while True:
        if time > 0:
            return time
        else:
            time = float(input("Wrong input. Try again: "))


def input_number(message):
    number = int(input(f"Enter {message}: ({message} > 0) "))
    while True:
        if number > 0:
            return number
        else:
            number = float(input("Wrong input. Try again: "))


def show_objects(array):
    for i in range(len(array)):
        print(f"{i+1})", end="")
        array[i].display_object()


def show_coordinates(array, t):
    for i in range(len(array)):
        x, y = array[i].get_coordinates(t)
        print(f"{i+1})\tx is: \t{round(x, 3)}\ty is: \t{round(y, 3)}")


def return_max_distance(array):
    first = 0
    second = 1
    max_distance = array[0].get_distance(array[0].get_x(), array[0].get_y())
    for o in range(len(array)-1):
        for i in range(len(array)):
            temp_max = array[o].get_distance(array[i].get_x(), array[i].get_y())
            if temp_max > max_distance:
                max_distance = temp_max
                first = o
                second = i
    return max_distance, first, second



