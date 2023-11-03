create database FitBoostTrainers;

CREATE TABLE [dbo].[Trainers] (
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [ExerciseName] NVARCHAR(255),
    [Difficulty] NVARCHAR(50),
    [Instructions] NVARCHAR(MAX),
    [VideoInstructions] NVARCHAR(MAX),
    [VideoInstructionsSecond] NVARCHAR(MAX),
    [MuscleType] NVARCHAR(50),
    [TrainersType] NVARCHAR(50)
);


INSERT INTO [dbo].[Trainers] (ExerciseName, Difficulty, Instructions, VideoInstructions, VideoInstructionsSecond, MuscleType, TrainersType)
VALUES
    ('������ �������� �������� ����������', '�������', '��������� ������ ������� �� ������.
�������� ���� ��� ������ � �������� ��������� ����, ����� ������� ������.
����������� �� ���� ����������.
��������� � �������� ���������.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-1-front.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-1-side.mp4', 'Forearms', 'stretches'),
    ('������ �������� �������� ����������', '�������', '�������� ���� � �����, ������ ���������� �����, ������� ������� �������������.
�������� ����������� � ������.
����������� �� ���� ����������.
��������� � �������� ���������.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-2-side.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-2-front.mp4', 'Forearms', 'stretches'),
    ('������ �������� �������� ����������', '�������', '��������� ���� ������.
��������� ���� � ����� �� 180 ��������.
����������� �� ���� ����������.
��������� � �������� ���������.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-3-front.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-3-side.mp4', 'Forearms', 'stretches'),
    ('��������� �������� �������� ����������', '�������', '��������� ���� �� ������� ����� ��� ����� 90 �������� � ����.
������ �������� �� ���� � �������� �� � ����.
��������� ���� ������� ����.
��������� ������� � ���������.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-4-front.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-4-side.mp4', 'Forearms', 'stretches')