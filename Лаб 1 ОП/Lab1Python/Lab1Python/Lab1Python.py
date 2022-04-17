def input_text():
    text = []
    print("Enter your text: (press CTRL + X and Enter to stop)")
    flag = True
    exit_line = "\u0018"
    while(flag):
        line = str(input())
        if (line == exit_line):
            flag = False
        else:
            text.append(line)
    return text

def create_file(path, text, append):
    open_mode = "wt"
    if append:
        open_mode = "at"
        text[0] = "\n" + text[0]
    with open(path, open_mode) as file:
        file.write(text[0])
        for i in range(1, len(text)):
            file.write('\n' + text[i])

def choose_append_or_not():
    while (True):
        choice = input("You want to add text or rewrite file? (Enter 'a' if you want to add text or 'r' if you want to rewrite text): ")
        if (choice == 'a'):
            return True
        if (choice == 'r'):
            return False
        else:
            print('Wrong symbol. Try again')
    

def display_file(path):
    with open(path, "rt") as file:
        for string in file:
            print(string,end='')
        print('\n')

def read_text(path):
    with open(path, "rt") as file:
            text = file.readlines()
    return text

def change_text(text):
    edited_text = []
    for line in text:
        if (line == "\n"):
            edited_text.append("")
            continue
        sentences_list = line.split('.')
        for sentence in sentences_list:
            sentence = sentence.strip()
            result = sentence
            sentence = sentence.replace(";" , " ")
            sentence = sentence.replace("," , " ")
            words_list = sentence.split(" ")
            min_length = len(words_list[0])
            min_word = words_list[0]
            for word in words_list:
                if ((len(word) < min_length) & (word != "")):
                    min_length = len(word)
                    min_word = word
            if (result == ""):
                continue
            result += " -=" + "Word with minimum length is : " + '"' + min_word + '"' + " and it's length is : " + str(min_length) + '=-'
            edited_text.append(result)
    return edited_text


file_path = "filePy.txt"
new_file_path = "newFilePy.txt"

text = input_text()
append = choose_append_or_not()
create_file(file_path, text, append)

print("Original file is: ")
display_file(file_path)

new_text = read_text(file_path)
changed_text = change_text(new_text)
create_file(new_file_path, changed_text, False)

print("New file is: ")
display_file(new_file_path)
