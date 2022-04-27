import pickle


def choose_append_or_not(path):
    input_mode = str(input("Do you want to add new info to existing file or clear it? (enter 'a' or 'c') \n \t"))
    while True:
        if input_mode == "a":
            break
        elif input_mode == "c":
            open(path, "wb").close()
            break
        else:
            input_mode = str(input("Wrong symbol. Try again: \n \t"))


def input_info():
    info = []
    line = input('''Enter information about phone calls: 
    (format: +XX0XXXXXXXXX HH:MM HH:MM), input empty line to stop + Enter  \n \t''')
    while line:
        if try_create_from_line(line):
            info.append(line)
        else:
            print("Error. Wrong input format")
        line = input("\t")
    return info


def try_create_from_line(line):
    elements = line.split()
    if len(elements) != 3:
        return False
    elif not is_phone_number_valid(elements[0]):
        return False
    elif not (is_time_valid(elements[1]) | is_time_valid(elements[2])):
        return False

    return True


def write_info(path, info):
    saved_info = []
    try:
        with open(path, "rb") as file:
            saved_info = pickle.load(file)
    except:
        pass
    for call in info:
        elements = call.split()
        call_info = {
            "phone_number": elements[0],
            "start_time": elements[1],
            "end_time": elements[2]
        }
        saved_info.append(call_info)
    with open(path, "wb") as file:
        pickle.dump(saved_info, file)
        print("File has been successfully written \n")


def write_without_shortest(path, info):
    with open(path, "wb") as file:
        pickle.dump(info, file)
    print("\nFile (without short calls) has been successfully written \n")


def read_info(path):
    with open(path, "rb") as file:
        info = pickle.load(file)
    return info


def show_info(info):
    for calls in info:
        print(f'{calls["phone_number"]} {calls["start_time"]} {calls["end_time"]}; '
              f'Price is: {get_price(calls["start_time"], calls["end_time"])}')


def get_price(start_time, end_time):
    price = 0
    total_duration_night = 0
    total_duration_day = 0
    price_day = 1.5
    price_night = 0.9

    zero_minute_of_the_day = 0
    last_minute_of_the_day = 24*60

    start_t = convert_time_into_minutes(start_time)
    end_t = convert_time_into_minutes(end_time)

    if start_t <= end_t:
        total_duration_day, total_duration_night = get_night_and_day_duration(start_t, end_t)
    else:
        first_duration_day, first_duration_night = get_night_and_day_duration(start_t, last_minute_of_the_day)
        second_duration_day, second_duration_night = get_night_and_day_duration(zero_minute_of_the_day, end_t)
        total_duration_day = first_duration_day + second_duration_day
        total_duration_night = first_duration_night + second_duration_night

    price = total_duration_night * price_night + total_duration_day * price_day
    return price


def get_night_and_day_duration(start_t, end_t):
    duration_night = 0
    duration_day = 0

    night_time = 20 * 60
    day_time = 9 * 60
    if start_t == end_t:
        duration_night = 0
        duration_day = 0
    elif start_t < end_t < day_time:
        duration_night = end_t - start_t
    elif (start_t < day_time) & (day_time <= end_t < night_time):
        duration_night = day_time - start_t
        duration_day = end_t - day_time
    elif (start_t < day_time) & (end_t >= night_time):
        duration_night = day_time - start_t + end_t - night_time
        duration_day = night_time - day_time
    elif (start_t >= day_time) & (start_t < end_t < night_time):
        duration_day = end_t - start_t
    elif (day_time <= start_t < night_time) & (end_t >= night_time):
        duration_day = night_time - start_t
        duration_night = end_t - night_time
    elif start_t >= night_time:
        duration_night = end_t - start_t

    return duration_day, duration_night


def delete_shortest(info):
    for calls in info:
        if get_duration(calls["start_time"], calls["end_time"]) < 3:
            info.remove(calls)


def get_duration(start_time, end_time):
    start_t = convert_time_into_minutes(start_time)
    end_t = convert_time_into_minutes(end_time)
    if start_t > end_t:
        return end_t + 24 * 60 - start_t
    return end_t - start_t


def convert_time_into_minutes(line):
    digits = line.split(":")
    return int(digits[0]) * 60 + int(digits[1])


def is_phone_number_valid(line):
    if len(line) != 13:
        return False
    if line[3] != '0':
        return False

    edited_line = line.replace('+', '1')
    if not edited_line.isdigit():
        return False

    return True


def is_time_valid(time):
    if (len(time) != 5) | (time[2] != ':'):
        return False

    edited_time = time.replace(':', '1')
    if not edited_time.isdigit():
        return False

    digits = time.split(':')
    if (int(digits[0]) > 23) | (int(digits[1]) > 59):
        return False

    return True
