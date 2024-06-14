import math
import cv2
import cvzone
from cvzone.ColorModule import ColorFinder
import numpy as np
cap = cv2.VideoCapture(0)
import socket
import time
#初始化色彩
myColorFinder = ColorFinder(False)
# 初始化hsv的初始值
hsvVals = {'hmin': 0, 'smin': 70, 'vmin': 50, 'hmax': 10, 'smax': 255, 'vmax': 255}

host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

#變數宣告
posListX,posListY = [],[]
xList = [item for item in range(0,1059)]
sock.connect((host, port))
while True:
    # 擷取影像
    success, img = cap.read()
    
    #img = cv2.imread(r"C:\Users\rzhan\Desktop\Videos\1.jpg")
    #img = img[0:800, :]

    # 找球
    imgColor, mask = myColorFinder.update(img,hsvVals)
    # 找球的位置
    imgContours, contours = cvzone.findContours(img,mask,minArea=500)
    # 若找到則取得座標 並在畫面標記中心
    if contours:
        cx,cy= contours[0]['center']
        print(cx,cy)
        cv2.circle(imgContours, (cx,cy), 5, (0,0,255), cv2.FILLED)
    

    #如果球的位置符合特定範圍，發送訊息到遊戲端
    #x values 636 to 702 y 232
    #x2 values 654 to 684 y 258
        if 430<cx<515 and 300>cy>240:    
            print(cx, cy)
            print("basket")
            data = "basket"
            time.sleep(0.5)
            sock.sendall(data.encode("utf-8"))
        if 440 < cx < 525 and (320 < cy or 180< cy < 230):
            data="Miss"
            sock.sendall(data.encode("utf-8"))
            time.sleep(0.01)
        if 55>cx:
            #`print("No basket")
            data = "No basket"
            time.sleep(0.1)
            sock.sendall(data.encode("utf-8"))
    #else:
        #print("No basket")
    
        
    # 畫面顯示
    imgContours = cv2.resize(imgContours,(0,0),None,0.7,0.7)
    #cv2.imshow("Image",img)
    cv2.imshow("ImageColor",imgContours)
    cv2.waitKey(50)