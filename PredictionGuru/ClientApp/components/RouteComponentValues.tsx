import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface CustomState {
    paramId: number;
}

export class RouteComponentValues extends React.Component<RouteComponentProps<{ id: number }>, CustomState> {
    constructor(props: RouteComponentProps<{ id: number }>) {
        super(props);
        this.state = { paramId: this.props.match.params.id };
    }

    public render() {
        return <div>
            {this.state.paramId}
        </div>;
    }
}