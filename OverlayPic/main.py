from PIL import Image
import os

back = 'Img/under.png'
front = 'Img/overlay_2023TagDerOffenerTür.png'

img1 = Image.open(back)

img2 = Image.open(front)

img1.paste(img2, (0,0), mask=img2)

img1.show()