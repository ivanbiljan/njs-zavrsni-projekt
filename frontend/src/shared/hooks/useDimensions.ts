import { RefObject, useCallback, useEffect, useState } from "react";

export const useDimensions = (objectRef: RefObject<any>) => {
    const [width, setWidth] = useState(0);
    const [height, setHeight] = useState(0);

    const updateDimensions = useCallback(() => {
        setWidth(objectRef.current.offsetWidth);
        setHeight(objectRef.current.offsetHeight);
    }, [objectRef]);

    useEffect(() => {
        if (objectRef.current) {
            updateDimensions();
        }

        window.addEventListener("resize", updateDimensions);

        return () => {
            window.removeEventListener("resize", updateDimensions);
        }
    }, [objectRef])

    return {width, height};
}