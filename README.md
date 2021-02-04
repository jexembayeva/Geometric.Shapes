﻿# Geometric.Shapes
Приложение для работы с геометрическими фигурами,
предоставляющее следующий API:

- Сервис, который принимает POST-запрос с параметрами фигуры
(круг и треугольник) и сохраняет ее в персистентное
хранилище. Сервис возвращает идентификатор фигуры.

- Сервис, который по GET-запросу с идентификатором фигуры возвращает
ее площадь, если фигура содержится в БД.