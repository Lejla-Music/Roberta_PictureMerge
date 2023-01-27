from PIL import Image
from PIL import ImageDraw
import time
from watchdog.observers import Observer
from watchdog.events import PatternMatchingEventHandler
from watchdog.events import FileSystemEventHandler
import os

back = 'Img/RobertaPicture.jpg'
front = 'Img/overlay_2023TagDerOffenerTür.png'
isDone = True


def createPic():
    dirPath = 'OutputPictures'
    count = 1

    for path in os.listdir(dirPath):
        if os.path.isfile(os.path.join(dirPath, path)):
            count += 1

    img1 = Image.open(back)

    img2 = Image.open(front)

    img1.paste(img2, (0, 0), mask=img2)

    img1.save(f'OutputPictures/{count}.png', 'PNG')


class Watcher:
    DIRECTORY_TO_WATCH = "Img"

    def __init__(self):
        self.observer = Observer()

    def run(self):
        event_handler = Handler()
        self.observer.schedule(
            event_handler, self.DIRECTORY_TO_WATCH, recursive=True)
        self.observer.start()
        try:
            while True:
                time.sleep(5)
        except:
            self.observer.stop()
            print("Error")

        self.observer.join()


class Handler(FileSystemEventHandler):

    @staticmethod
    def on_any_event(event):
        if event.is_directory:
            return None

        elif event.event_type == 'created':
            print("Received created event - %s." % event.src_path)

        elif event.event_type == 'modified':
            print("Picture Received")
            time.sleep(3)
            createPic()


if __name__ == '__main__':
    w = Watcher()
    w.run()
