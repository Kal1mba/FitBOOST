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
    ('Первая вариация растяжки предплечий', 'Новичок', 'Поместите ладонь вровень со стеной.
Сделайте один шаг вперед и медленно выпрямите руку, чтобы размять бицепс.
Задержитесь на пике растяжения.
Вернитесь в исходное положение.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-1-front.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-1-side.mp4', 'Forearms', 'stretches'),
    ('Вторая вариация растяжки предплечий', 'Новичок', 'Прижмите руку к стене, ладони направлены вверх, кончики пальцев соприкасаются.
Медленно наклонитесь к ладони.
Задержитесь на пике растяжения.
Вернитесь в исходное положение.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-2-side.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-2-front.mp4', 'Forearms', 'stretches'),
    ('Третья вариация растяжки предплечий', 'Новичок', 'Поместите руки вместе.
Поверните руки и кисти на 180 градусов.
Задержитесь на пике растяжения.
Вернитесь в исходное положение.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-3-front.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-3-side.mp4', 'Forearms', 'stretches'),
    ('Четвертая вариация растяжки предплечий', 'Новичок', 'Поднимите руку на уровень плеча под углом 90 градусов к телу.
Слегка надавите на руку и толкайте ее к себе.
Поверните руку поперек тела.
Поменяйте стороны и повторите.', 'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-4-front.mp4',
'https://media.musclewiki.com/media/uploads/videos/branded/male-forearms-stretch-variation-4-side.mp4', 'Forearms', 'stretches')