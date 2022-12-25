export interface IconProps {
    width: number;
    height: number;
    color: string;
}

export type Icon = (props: IconProps) => JSX.Element;