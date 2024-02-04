import cv2 as cv
import numpy as np


class helper:
    def CheckPixelThreshold(pixel, pixelCoordinateList):
        result = ""

        (pixelR, pixelG, pixelB, pixelX, pixelY) = pixel

        if pixelR == 0 and pixelG == 0 and pixelB == 0:
            if pixelR < 0 or pixelG < 0 or pixelB < 0:
                print(pixelR + " - " + pixelG + " - " + pixelB)
            return None
        #

        redPixelValueWeWant = [255, 0, 0]
        greenPixelValueWeWant = [0, 255, 0]
        bluePixelValueWeWant = [0, 0, 255]

        cyanPixelValueWeWant = [0, 255, 255]
        yellowPixelValueWeWant = [255, 255, 0]
        purpPixelValueWeWant = [255, 0, 255]

        whitePixelValueWeWant = [255, 255, 255]

        if (
            pixelR == whitePixelValueWeWant[0]
            and pixelG == whitePixelValueWeWant[1]
            and pixelB == whitePixelValueWeWant[2]
        ):
            result = "White"
        #

        elif (
            pixelR == cyanPixelValueWeWant[0]
            and pixelG == cyanPixelValueWeWant[1]
            and pixelB == cyanPixelValueWeWant[2]
        ):
            result = "Orange"
        #

        elif (
            pixelR == yellowPixelValueWeWant[0]
            and pixelG == yellowPixelValueWeWant[1]
            and pixelB == yellowPixelValueWeWant[2]
        ):
            result = "Yellow"
        #

        elif (
            pixelR == purpPixelValueWeWant[0]
            and pixelG == purpPixelValueWeWant[1]
            and pixelB == purpPixelValueWeWant[2]
        ):
            result = "Purple"
        #

        elif (
            pixelR == redPixelValueWeWant[0]
            and pixelG == redPixelValueWeWant[1]
            and pixelB == redPixelValueWeWant[2]
        ):
            result = "Red"
        #

        elif (
            pixelR == greenPixelValueWeWant[0]
            and pixelG == greenPixelValueWeWant[1]
            and pixelB == greenPixelValueWeWant[2]
        ):
            result = "Green"
        #

        elif (
            pixelR == bluePixelValueWeWant[0]
            and pixelG == bluePixelValueWeWant[1]
            and pixelB == bluePixelValueWeWant[2]
        ):
            result = "Blue"
        #
        else:
            return None
        #

        # clonePixelCoordinateList = helper.CloneList(pixelCoordinateList)

        # clonePixelCoordinateList = helper.ReverseList(clonePixelCoordinateList)

        if False:
            pixelCoordinateList.append((result, pixelX, pixelY))

            return result
        #

        i = 0

        for coordinateIndex in range(len(pixelCoordinateList)):
            (colorString, coordinateX, coordinateY) = pixelCoordinateList[
                len(pixelCoordinateList) - 1 - coordinateIndex
            ]

            i += i
            if i == 7:
                return None
            #
            # if result != colorString:
            #     continue
            # #
            if (
                pixelX - 1 == coordinateX  # or pixelX - 2 == coordinateX
            ):  # if the pixel next to curr pixel is already saved
                return None
            #
            elif (
                pixelX + 1 == coordinateX  # or pixelX + 2 == coordinateX
            ):  # if the pixel next to curr pixel is already saved
                return None
            #
            elif (
                pixelY - 1 == coordinateY  # or pixelY - 2 == coordinateY
            ):  # if the pixel next to curr pixel is already saved
                return None
            #
            elif (
                pixelY + 1 == coordinateY  # or pixelY + 2 == coordinateY
            ):  # if the pixel next to curr pixel is already saved
                return None
                #
            #
        #

        pixelCoordinateList.append((result, pixelX, pixelY))

        return result

    def CloneList(listToClone):
        list_copy = listToClone[:]
        return list_copy

    def ReverseList(listToReverse):
        reversedList = listToReverse[::-1]
        return reversedList
