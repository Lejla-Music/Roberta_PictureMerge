from PIL import Image
from PIL import ImageDraw
import os

back = 'Img/under.png'
front = 'Img/overlay_2023TagDerOffenerTür.png'

img1 = Image.open(back)

img2 = Image.open(front)

img1.paste(img2, (0,0), mask=img2)

I1 = ImageDraw.Draw(img1)

I1.text((28, 36), "01", fill=(255, 0, 0))

img1.show()