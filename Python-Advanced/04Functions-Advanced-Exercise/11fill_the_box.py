def fill_the_box(height, length, width, *args):
    space = height * length * width
    initial_space = space

    is_enough_space = True
    left_cubes = 0

    for arg in args:
        if arg == 'Finish':
            break

        element = int(arg)

        if element > space and is_enough_space:
            is_enough_space = False
            element -= space

        if is_enough_space:
            space -= element
        else:
            left_cubes += element

    if is_enough_space:
        return f'There is free space in the box. You could put {space} more cubes.'
    else:
        return f'No more free space! You have {left_cubes} more cubes.'


print(fill_the_box(5, 5, 2, 40, 11, 7, 3, 1, 5, "Finish"))
