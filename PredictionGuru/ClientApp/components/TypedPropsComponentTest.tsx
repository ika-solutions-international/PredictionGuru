import * as React from 'react';

export default class TypedPropsComponentTest extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = { dialog: this.props.parentDialog };
    }

    public render() {
        return (
            <div style={{ color: 'red' }}>
                Testing Typed Porps Coponent Says: <b>{this.state.dialog}!</b>
            </div>
        );
    }
}