import cv2 as cv
import numpy as np


class helper:
    def CheckPixelThreshold(thresholdValues, pixel, pixelCoordinateList):
        result = ""

        (pixelRThresh, pixelGThresh, pixelBThresh) = thresholdValues

        (pixelR, pixelG, pixelB, pixelX, pixelY) = pixel

        if pixelR == 0 and pixelG == 0 and pixelB == 0:
            return None
        #this?
        # yea its just not having } for closing
        # i use # to show where its closing

        rThreshPassed = False
        gThreshPassed = False
        bThreshPassed = False

        if pixelR > pixelRThresh:
            rThreshPassed = True
        if pixelG > pixelGThresh:
            gThreshPassed = True
        if pixelB > pixelBThresh:
            bThreshPassed = True

        if rThreshPassed and not gThreshPassed and not bThreshPassed:
            result = "Red"
        #

        elif not rThreshPassed and gThreshPassed and not bThreshPassed:
            result = "Green"
        #

        elif not rThreshPassed and not gThreshPassed and bThreshPassed:
            result = "Blue"
        #

        elif rThreshPassed and gThreshPassed and not bThreshPassed:
            result = "Orange"
        #

        elif rThreshPassed and gThreshPassed and not bThreshPassed:
            result = "Yellow"
        #

        elif rThreshPassed and not gThreshPassed and bThreshPassed:
            result = "Purple"
        #

        elif rThreshPassed and gThreshPassed and bThreshPassed:  # on what
            result = "White"
        #

        for colorString, coordinateX, coordinateY in pixelCoordinateList:
            if result == colorString: 
                if (

                    not coordinateX - 1 < pixelX < coordinateX + 1 
                    or not coordinateY - 1 < pixelY < coordinateY + 1  
                ):  # thinking is hard
                    continue
                #
            #
        # im probly the first programmer on nbi
        # man this takes quite long
        # 
        # 
        # 
        # 
                

        


        pixelCoordinateList.append((result, pixelX, pixelY))

        return result
