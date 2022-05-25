from abc import ABC, abstractmethod
import random
import math


class MovingPointParticle(ABC):
    @abstractmethod
    def get_coordinates(self, t):
        pass

    @abstractmethod
    def get_distance(self, x2, y2):
        pass

    @abstractmethod
    def display_object(self):
        pass


class MovingPointParticleX(MovingPointParticle):

    def get_y(self):
        return self.__y

    def get_x0(self):
        return self.__x0

    def get_x(self):
        return self.__x

    def get_a1(self):
        return self.__a1

    def __init__(self):
        min_rand_x = -100
        max_rand_x = 100
        min_rand_a = -10
        max_rand_a = 10
        precision = 10

        self.__x = 0
        self.__y = 0
        self.__x0 = random.randint(min_rand_x * precision, max_rand_x * precision) / precision
        self.__a1 = random.randint(min_rand_a * precision, max_rand_a * precision) / precision

    def get_coordinates(self, t):
        self.__x = self.__x0 + self.__a1 * math.sin(t)
        return self.__x, 0

    def get_distance(self, x2, y2):
        return abs(x2 - self.__x)

    def display_object(self):
        print(f"\ta1 = {self.__a1}\tx0 = {self.__x0}")


class MovingPointParticleXY(MovingPointParticle):

    def get_x0(self):
        return self.__x0

    def get_y0(self):
        return self.__y0

    def get_x(self):
        return self.__x

    def get_y(self):
        return self.__y

    def get_a1(self):
        return self.__a1

    def get_a2(self):
        return self.__a2

    def __init__(self):
        min_rand_x = -100
        max_rand_x = 100
        min_rand_y = -100
        max_rand_y = 100
        min_rand_a1 = -10
        max_rand_a1 = 10
        min_rand_a2 = -10
        max_rand_a2 = 10
        precision = 10

        self.__x = 0
        self.__y = 0
        self.__x0 = random.randint(min_rand_x * precision, max_rand_x * precision) / precision
        self.__y0 = random.randint(min_rand_y * precision, max_rand_y * precision) / precision
        self.__a1 = random.randint(min_rand_a1 * precision, max_rand_a1 * precision) / precision
        self.__a2 = random.randint(min_rand_a2 * precision, max_rand_a2 * precision) / precision

    def get_coordinates(self, t):
        self.__x = self.__x0 + self.__a1 * math.sin(t)
        self.__y = self.__y0 + self.__a2 * math.cos(t)
        return self.__x, self.__y

    def get_distance(self, x2, y2):
        return math.sqrt((x2 - self.__x) ** 2 + (y2 - self.__y) ** 2)

    def display_object(self):
        print(f"\ta1 = {self.__a1}\ta2 = {self.__a2}\tx0 = {self.__x0}\ty0 = {self.__y0}")