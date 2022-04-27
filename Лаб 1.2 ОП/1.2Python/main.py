from module1 import *

path = "conversations.bat"
choose_append_or_not(path)
list_of_calls = input_info()

write_info(path, list_of_calls)
new_list_of_calls = read_info(path)

print("Written file is: ")
show_info(new_list_of_calls)
delete_shortest(new_list_of_calls)

write_without_shortest(path, new_list_of_calls)
final_list_of_calls = read_info(path)
print("Final file without short calls is: ")
show_info(final_list_of_calls)
